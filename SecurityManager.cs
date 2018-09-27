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
            String dataFilePath = String.Concat(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, @"\data.txt");
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was problem with File", e.GetType().Name);
                return false;
            }
            String line;
          
            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                       String dbEmail = line;

                       String[] tokens = dbEmail.Split(' ');

                       if(tokens.Length == 3) { 
                           String mail = String.Copy(tokens[1]);
                            Console.WriteLine(String.Concat("Comparing ", mail, " and ", email, ": "));
                           if (String.Compare(email, mail).CompareTo(0) == 0)
                            {
                                Console.WriteLine("your email has been found, sending password");
                                String passwordHash = tokens[2];
                                String usrname = tokens[0];

                                var messg = new MimeMessage();
                                messg.From.Add(new MailboxAddress("your Whos_that password", "bot@whos_mail.com"));

                                Console.WriteLine("Sending email to " + email);
                                messg.To.Add(new MailboxAddress("email_to", email));
                                messg.Subject = "Your Whos_that Password";

                                var builder = new BodyBuilder();

                                builder.TextBody = String.Concat("Here's your password hash, do whatever you want with it:",tokens[2]);

                                messg.Body = builder.ToMessageBody();

                                try
                                {
                                    var client = new SmtpClient();
                                    client.Connect("smtp.gmail.com", 465, true);
                                    client.Authenticate("whos.that.robobat@gmail.com", "robobatforever");
                                    client.Send(messg);
                                    client.Disconnect(true);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Send Mail failed: " + e.Message);
                                }
                                Console.ReadLine();
                                //Console.WriteLine("FOUND!");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No File");
            }
            //Close File
            fileRead.Close();
            //throw new NotImplementedException();
            return true;
        }
    }
}
