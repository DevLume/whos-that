using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Drawing;
//the code below is magic from stackoverflow.
namespace Whos_that
{
    public class PlaceholderTextBox : TextBox 
    {
        bool isPlaceholder = true;
        string placeholderText;

        public string PlaceholderText
        {
            get { return placeholderText; }
            set {
                placeholderText = value;
                setPlaceholder();
            }
        }

        public new string Text
        {
            get => isPlaceholder ? string.Empty : base.Text;
            set => base.Text = value;
        }

        private void setPlaceholder() {
            if (string.IsNullOrEmpty(base.Text)) {
                base.Text = placeholderText;
                this.ForeColor = Color.Gray;
                this.Font = new Font(this.Font, FontStyle.Italic);
                isPlaceholder = true;
            }
        }

        private void removePlaceholder() {
            if (isPlaceholder) {
                base.Text = "";
                this.ForeColor = SystemColors.WindowText;
                this.Font = new Font(this.Font, FontStyle.Regular);
                isPlaceholder = false;
            }
        }

        public PlaceholderTextBox() {
            GotFocus += removePlaceholder;
            LostFocus += setPlaceholder;
        }

        private void setPlaceholder(object sender, EventArgs e) {
            setPlaceholder();
        }

        private void removePlaceholder(object sender, EventArgs e) {
            removePlaceholder();
        }
    }
}
