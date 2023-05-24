using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace dentalConnectDAO.Implementation
{
    public static class Validations
    {
  
            private static readonly Regex regex = new Regex("[^a-zA-Z0-9]+");
            private static readonly Regex regexNum = new Regex("[^0-9]+");
            private static readonly Regex regexText = new Regex("[^a-zA-Z]+");
            private static readonly Regex regexEmail = new Regex("[^a-zA-Z0-9.@ ]+");
            private static readonly Regex regexStreets = new Regex("[^a-zA-Z0-9., ]+");

        public static void ApplyTextInputValidation(TextBox textBox)
        {
            textBox.TextChanged += TextBox_TextChanged;
        }

        public static void TextIntputNumbers(TextBox textBoxN)
        {
           textBoxN.TextChanged += TextNum_TextChanged;
        }

        public static void TextIntputText(TextBox textBoxN)
        {
            textBoxN.TextChanged += Text_TextChanged;
        }

        public static void TextIntputEmail(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextAllowedCharacters_Email;
        }
        public static void TextIntputStreet(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextAllowedStreet;
        }

        private static void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
                TextBox textBox = (TextBox)sender;
                string newText = textBox.Text;

                if (regex.IsMatch(newText))
                {
                    int caretIndex = textBox.CaretIndex;
                    textBox.Text = regex.Replace(newText, string.Empty);
                    textBox.CaretIndex = caretIndex - 1;
                }
        }
        private static void TextAllowedCharacters_Email(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexEmail.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexEmail.Replace(newText, string.Empty);

                if (caretIndex > 0)
                {
                    textBox.CaretIndex = caretIndex - 1;
                }
                else
                {
                    textBox.CaretIndex = 0;
                }
            }
        }

        private static void TextNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexNum.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexNum.Replace(newText, string.Empty);

                if (caretIndex > 0)
                {
                    textBox.CaretIndex = caretIndex - 1;
                }
                else
                {
                    textBox.CaretIndex = 0;
                }
            }
        }

        private static void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexText.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexText.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }

        private static void TextAllowedStreet(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexStreets.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexStreets.Replace(newText, string.Empty);

                if (caretIndex > 0)
                {
                    textBox.CaretIndex = caretIndex - 1;
                }
                else
                {
                    textBox.CaretIndex = 0;
                }
            }
        }

    }
}
