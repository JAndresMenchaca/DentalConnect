using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data.SqlClient;

namespace dentalConnectDAO.Implementation
{
    public static class ValidationsImpl
    {
        #region "Category"

        //Name

        private static readonly Regex regexText = new Regex("[^a-zA-ZáéíóúüÉÁÚÍÓÜñÑ ]+");
        private static readonly Regex regexNameCategory = new Regex("^(?!.*  )[a-zA-ZáéíóúüÉÁÚÍÓÜñÑ ]{0,50}$");

        //Description
        private static readonly Regex regexCaracter = new Regex("[^a-zA-ZáéíóúüÉÁÚÍÓÜñÑ.,!¡/?¿()$%:;0-9´& ]+");
        private static readonly Regex regexDescription = new Regex("^(?!.*  )[a-zA-Z0-9.,!¡/?¿()$%áéíóúüñÑ0-9´& ]{0,80}$");

        #endregion

        #region "Supplier"
        //Nombre
        private static readonly Regex regexNameSupplier = new Regex("[^a-zA-Z0-9&.áéíóúüÉÁÚÍÓÜñÑ´ -]+");
        private static readonly Regex regexNameSupplier1 = new Regex("^(?!.*  )[a-zA-Z0-9&.áéíóúüÉÁÚÍÓÜñÑ´ -]{0,50}$");
        //Telefono
        private static readonly Regex regexPhoneSupplier = new Regex("[^0-9+ -]+");
        private static readonly Regex regexPhoneSupplier1 = new Regex("^(?!.*  )[^0-9+ -]{0,20}$");
        //Email
        private static readonly Regex regexEmailSupplier = new Regex("[^a-zA-Z0-9.@]+");
        private static readonly Regex regexEmailSupplier1 = new Regex("^(?!.*  )[^a-zA-Z0-9.@]{0,30}$");

        //Sitio Web
        private static readonly Regex regexWebSupplier = new Regex("[^a-zA-Z0-9.-]+");
        private static readonly Regex regexWebSupplier1 = new Regex("^(?!.*  )[^a-zA-Z0-9.-]{0,60}$");
        //Calle Principal y Calle Adyacente

        private static readonly Regex regexStreetSupplier = new Regex("[^a-zA-Z0-9ñÑ .#/-]+");
        private static readonly Regex regexStreetSupplier1 = new Regex("^(?!.*  )[^a-zA-Z0-9ñÑ .#/-]{0,30}$");

        #endregion

        #region"User"

        //Ci
        private static readonly Regex regexCiUser = new Regex("[^A-Z0-9-]+");
        private static readonly Regex regexCiUser1 = new Regex("^(?!.*  )[A-Z0-9-]{0,15}$");
        //Nombre y Primer y Segundo Apellido
        private static readonly Regex regexNameUser = new Regex("[^a-zA-ZáéíóúüÉÁÚÍÓÜñÑ ]+");
        private static readonly Regex regexNameUser1 = new Regex("^(?!.*  )[a-zA-ZáéíóúüÉÁÚÍÓÜñÑ ]{0,60}$");
        //Email
        //usamos la misma que en Supplier
        //Telefono
        private static readonly Regex regexPhoneUser = new Regex("[^0-9]+");
        private static readonly Regex regexPhoneUser1 = new Regex("^(?!.*  )[0-9]{0,8}$");


        #endregion

        #region Products
        //Nombre
        private static readonly Regex regexNameProduct = new Regex("[^a-zA-Z0-9&.áéíóúüÉÁÚÍÓÜñÑ´ -]+");
        private static readonly Regex regexNameProduct1 = new Regex("^(?!.*  )[a-zA-Z0-9&.áéíóúüÉÁÚÍÓÜñÑ´ -]{0,40}$");
        //Descrip
        // usamos la misma que en Category
        //Precio
        private static readonly Regex regexPriceProduct = new Regex("[^0-9,]+");
        private static readonly Regex regexPriceProduct1 = new Regex("^(?!.*  )[^0-9,]{0,7}$"); 
        //Stock
        private static readonly Regex regexStockProduct = new Regex("[^0-9]+");
        private static readonly Regex regexStockProduct1 = new Regex("^(?!.*  )[^0-9]{0,7}$");

        #endregion

        #region "methodsUser"
        public static void TextPhoneU1(TextBox textBox)
        {
            textBox.TextChanged += TextPhoneUser1;
        }
        public static void TextPhoneU(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextPhoneUser;
        }


        public static void TextNameU1(TextBox textBox)
        {
            textBox.TextChanged += TextNameUser1;
        }

        public static void TextNameU(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextNameUser;
        }


        public static void TextCiU1(TextBox textBox)
        {
            textBox.TextChanged += TextCiuser1;
        }

        public static void TextCiU(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextCiuser;
        }

        private static void TextCiuser(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexCiUser.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexCiUser.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextCiuser1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 15 || StartsOrEndsWithSpace(newText) || regexCiUser1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 15)
                {
                    filteredText = filteredText.Substring(0, 15);
                    caretIndex = Math.Min(caretIndex, 15);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }

        private static void TextNameUser(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexNameUser.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexNameUser.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextNameUser1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 60 || StartsOrEndsWithSpace(newText) || regexNameUser1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 60)
                {
                    filteredText = filteredText.Substring(0, 60);
                    caretIndex = Math.Min(caretIndex, 60);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }

        private static void TextPhoneUser(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexPhoneUser.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexPhoneUser.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextPhoneUser1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 8 || StartsOrEndsWithSpace(newText) || regexPhoneUser1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 8)
                {
                    filteredText = filteredText.Substring(0, 8);
                    caretIndex = Math.Min(caretIndex, 8);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }

        #endregion

        #region "methodsSupplier"
        public static void TextStreetS1(TextBox textBox)
        {
            textBox.TextChanged += TextStreetSupplier1;
        }

        public static void TextStreetS(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextStreetSupplier;
        }

        public static void TextWebS1(TextBox textBox)
        {
            textBox.TextChanged += TextWebSupplier1;
        }

        public static void TextWebS(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextWebSupplier;
        }


        public static void TextEmailS1(TextBox textBox)
        {
            textBox.TextChanged += TextEmailSupplier1;
        }

        public static void TextEmailS(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextEmailSupplier;
        }

        public static void TextNameS1(TextBox textBox)
        {
            textBox.TextChanged += TextNameSupplier1;
        }

        public static void TextNameS(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextNameSupplier;
        }

        public static void TextPhoneS1(TextBox textBox)
        {
            textBox.TextChanged += TextPhoneSupplier1;
        }

        public static void TextPhoneS(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextPhoneSupplier;
        }

        private static void TextNameSupplier(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexNameSupplier.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexNameSupplier.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextNameSupplier1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 80 || StartsOrEndsWithSpace(newText) || regexNameSupplier1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 80)
                {
                    filteredText = filteredText.Substring(0, 80);
                    caretIndex = Math.Min(caretIndex, 80);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }

        private static void TextPhoneSupplier(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexPhoneSupplier.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexPhoneSupplier.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextPhoneSupplier1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 20 || StartsOrEndsWithSpace(newText) || regexPhoneSupplier1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 20)
                {
                    filteredText = filteredText.Substring(0, 20);
                    caretIndex = Math.Min(caretIndex, 20);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }


        private static void TextEmailSupplier(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexEmailSupplier.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexEmailSupplier.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextEmailSupplier1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 30 || StartsOrEndsWithSpace(newText) || regexEmailSupplier1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 30)
                {
                    filteredText = filteredText.Substring(0, 30);
                    caretIndex = Math.Min(caretIndex, 30);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }

        private static void TextWebSupplier(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexWebSupplier.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexWebSupplier.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextWebSupplier1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 60 || StartsOrEndsWithSpace(newText) || regexWebSupplier1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 60)
                {
                    filteredText = filteredText.Substring(0, 60);
                    caretIndex = Math.Min(caretIndex, 60);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }

        private static void TextStreetSupplier(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexStreetSupplier.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexStreetSupplier.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextStreetSupplier1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 30 || StartsOrEndsWithSpace(newText) || regexStreetSupplier1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 30)
                {
                    filteredText = filteredText.Substring(0, 30);
                    caretIndex = Math.Min(caretIndex, 30);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }

        #endregion

        #region"methodCategory"
        public static void TextIntputText(TextBox textBoxN)
        {
            textBoxN.TextChanged += Text_TextChanged;
        }

        public static void TextForDescription(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextDescription;
        }
        public static void TextForNameCategory(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextNameCategory;
        }

        public static void TextForCaracter(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextCaracter;
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

        private static void TextCaracter(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexCaracter.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexCaracter.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }

        private static void TextDescription(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 80 || StartsOrEndsWithSpace(newText) || regexDescription.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 80)
                {
                    filteredText = filteredText.Substring(0, 80);
                    caretIndex = Math.Min(caretIndex, 80);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }


        private static void TextNameCategory(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 50 || StartsOrEndsWithSpace(newText) || regexNameCategory.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 50)
                {
                    filteredText = filteredText.Substring(0, 50);
                    caretIndex = Math.Min(caretIndex, 50);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }

        #endregion

        #region methodProduct
        public static void TextNameP1(TextBox textBox)
        {
            textBox.TextChanged += TextNameProduct1;
        }
        public static void TextNameP(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextNameProduct;
        }
        private static void TextNameProduct(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexNameProduct.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexNameProduct.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextNameProduct1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 40 || StartsOrEndsWithSpace(newText) || regexNameProduct1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 40)
                {
                    filteredText = filteredText.Substring(0, 40);
                    caretIndex = Math.Min(caretIndex, 40);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }


        public static void TextPriceP1(TextBox textBox)
        {
            textBox.TextChanged += TextPriceProduct1;
        }
        public static void TextPriceP(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextPriceProduct;
        }
        private static void TextPriceProduct(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexPriceProduct.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexPriceProduct.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextPriceProduct1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 7 || StartsOrEndsWithSpace(newText) || regexPriceProduct1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 7)
                {
                    filteredText = filteredText.Substring(0, 7);
                    caretIndex = Math.Min(caretIndex, 7);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }


        public static void TextStockP1(TextBox textBox)
        {
            textBox.TextChanged += TextStockProduct1;
        }
        public static void TextStockP(TextBox textBoxN)
        {
            textBoxN.TextChanged += TextStockProduct;
        }
        private static void TextStockProduct(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (regexStockProduct.IsMatch(newText))
            {
                int caretIndex = textBox.CaretIndex;
                textBox.Text = regexStockProduct.Replace(newText, string.Empty);
                textBox.CaretIndex = caretIndex - 1;
            }
        }
        private static void TextStockProduct1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newText = textBox.Text;

            if (newText.Length > 7 || StartsOrEndsWithSpace(newText) || regexStockProduct1.IsMatch(newText) || ContainsConsecutiveSpaces(newText))
            {
                int caretIndex = textBox.CaretIndex;
                string filteredText = newText;

                // Eliminar espacios consecutivos
                filteredText = RemoveConsecutiveSpaces(filteredText);

                if (filteredText.Length > 7)
                {
                    filteredText = filteredText.Substring(0, 7);
                    caretIndex = Math.Min(caretIndex, 7);
                }

                textBox.Text = filteredText;
                textBox.CaretIndex = caretIndex;
            }
        }





        #endregion

        private static bool StartsOrEndsWithSpace(string text)
        {
            return text.Trim() != text;
        }

        private static bool ContainsConsecutiveSpaces(string text)
        {
            return text.Contains("  ");
        }

        private static string RemoveConsecutiveSpaces(string text)
        {
            return text.Replace("  ", "");
        }


    }
}