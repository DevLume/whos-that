using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;


namespace Whos_that
{
    public class SecurityManager : ISecurityManager
    {
        private const string initVector = "pemgail9uzpgzl88";
        private const int keysize = 256;
        private IDataManager dataman;
        public SecurityManager() : this(DataManager.GetDataManager()) { }
        public SecurityManager(IDataManager dataman)
        {
            this.dataman = dataman;
        }

        public string ChangePassword()
        {
            throw new NotImplementedException();
        }

        public string DehashPassword(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        public string HashPassword(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public bool RemindPassword(string email)
        {
            //DataFileManager dataMan = new DataFileManager();
            //string[] temp = dataMan.GetDataLine(null, email);
            UserData user = dataman.GetUserDataByEmail(email);
            if (user.passHash != null)
            {
                string dehashedPass = DehashPassword(user.passHash, user.name);
                var messg = new MimeMessage();
                messg.From.Add(new MailboxAddress("your Whos_that password", "bot@whos_mail.com"));

                messg.To.Add(new MailboxAddress("email_to", email));
                messg.Subject = "Your Whos_that Password";

                var builder = new BodyBuilder();

                builder.TextBody = String.Concat("Here's your password: ", dehashedPass);

                messg.Body = builder.ToMessageBody();

                try
                {
                    var client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("whos.that.robobat@gmail.com", "robobatforever");
                    client.Send(messg);
                    client.Disconnect(true);
                }
                catch (Exception e) {
                    Console.WriteLine("Send mail Failed: " + e.Message);
                    return false;
                }
            }
            else MessageBox.Show("No account with such email is found");

            return true;
        }
    }
}