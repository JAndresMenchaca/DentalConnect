﻿using System;
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

        public static bool ValidateName(string name)
        {
            // Verificar si el nombre cumple con el patrón de la expresión regular
            bool isValid = regexNameCategory.IsMatch(name);

            return isValid;
        }

        //Description
        private static readonly Regex regexCaracter = new Regex("[^a-zA-ZáéíóúüÉÁÚÍÓÜñÑ.,!¡/?¿()$%:;0-9´& ]+");
        private static readonly Regex regexDescription = new Regex("^(?!.*  )[a-zA-Z0-9.,!¡/?¿()$%áéíóúüñÑ0-9´& ]{0,80}$");

        public static bool ValidateDescription(string description)
        {
            // Verificar si la descripción cumple con el patrón de la expresión regular
            bool isValid = regexDescription.IsMatch(description);

            return isValid;
        }

        #endregion

        #region "Supplier"
        //Nombre
        private static readonly Regex regexNameSupplier = new Regex("[^a-zA-Z0-9&.áéíóúüÉÁÚÍÓÜñÑ´ -]+");
        private static readonly Regex regexNameSupplier1 = new Regex("^(?!.*  )[a-zA-Z0-9&.áéíóúüÉÁÚÍÓÜñÑ´ -]{0,50}$");

        public static bool ValidateNameS(string name)
        {
            // Verificar si el nombre cumple con el patrón de la expresión regular
            bool isValid = regexNameSupplier1.IsMatch(name);

            return isValid;
        }
        //Telefono
        private static readonly Regex regexPhoneSupplier = new Regex("[^0-9+-]+");
        private static readonly Regex regexPhoneSupplier1 = new Regex("^(?!.*  )[^0-9+-]{0,20}$");
        private static readonly Regex regexPhoneSupplier2 = new Regex(@"^[0-9+-]{0,20}$");

        public static bool ValidatePhoneS(string phone)
        {
            bool isValid = regexPhoneSupplier2.IsMatch(phone);

            return isValid;
        }
        //Email
        private static readonly Regex regexEmailSupplier = new Regex("[^a-zA-Z0-9.@]+");
        private static readonly Regex regexEmailSupplier1 = new Regex("^(?!.*  )[^a-zA-Z0-9.@]{0,30}$");
        private static readonly Regex regexEmailSupplier2 = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]{0,30}$");

        public static bool ValidateEmailS(string email)
        {
            bool isValid = regexEmailSupplier2.IsMatch(email);

            return isValid;
        }
        //Sitio Web
        private static readonly Regex regexWebSupplier = new Regex("[^a-zA-Z0-9.-]+");
        private static readonly Regex regexWebSupplier1 = new Regex("^(?!.*  )[^a-zA-Z0-9.-]{0,60}$");
        private static readonly Regex regexWebSupplier2 = new Regex(@"^[a-zA-Z0-9.-]{0,60}$");

        public static bool ValidateWebS(string web)
        {
            bool isValid = regexWebSupplier2.IsMatch(web);

            return isValid;
        }
        //Calle Principal y Calle Adyacente

        private static readonly Regex regexStreetSupplier = new Regex("[^a-zA-Z0-9ñÑ .#/-]+");
        private static readonly Regex regexStreetSupplier1 = new Regex("^(?!.*  )[^a-zA-Z0-9ñÑ .#/-]{0,30}$");
        private static readonly Regex regexStreetSupplier2 = new Regex(@"^[a-zA-Z0-9ñÑ .#/-]{0,30}$");

        public static bool ValidateStreetS(string street)
        {
            bool isValid = regexStreetSupplier2.IsMatch(street);

            return isValid;
        }
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

        #region "Customer"
        //Nombre
        private static readonly Regex regexNameCustomer = new Regex("[^a-zA-Z0-9&.áéíóúüÉÁÚÍÓÜñÑ´ -]+");
        private static readonly Regex regexNameCustomer1 = new Regex("^(?!.*  )[a-zA-Z&.áéíóúüÉÁÚÍÓÜñÑ´ -]{0,50}$");

        public static bool ValidateNameC(string name)
        {
            // Verificar si el nombre cumple con el patrón de la expresión regular
            bool isValid = regexNameCustomer1.IsMatch(name);

            return isValid;
        }
        //CI
        private static readonly Regex regexCiCustomer = new Regex("[^A-Z0-9-]+");
        private static readonly Regex regexCiCustomer1 = new Regex("^(?!.*  )[A-Z0-9-]{0,15}$");

        public static bool ValidateCiC(string ci)
        {

            bool isValid = regexCiCustomer1.IsMatch(ci);

            return isValid;
        }

        //Email
        private static readonly Regex regexEmailCustomer2 = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]{0,30}$");

        public static bool ValidateEmailC(string email)
        {
            bool isValid = regexEmailCustomer2.IsMatch(email);

            return isValid;
        }
        //Telefono
        private static readonly Regex regexPhoneCustomer2 = new Regex(@"^[0-9+-]{0,20}$");

        public static bool ValidatePhoneC(string phone)
        {
            bool isValid = regexPhoneCustomer2.IsMatch(phone);

            return isValid;
        }
        //NIT
        private static readonly Regex regexNit = new Regex("^(?!.*  )[A-Z0-9-]{0,15}$");

        public static bool ValidateNit(string nit)
        {
            bool isValid = regexNit.IsMatch(nit);

            return isValid;
        }

        public static bool ValidateSpecificNit(string nit)
        {
            // Patrón para validar el formato específico del NIT: XXXX-XXXXXX-XXX-X
            string pattern = @"^\d{4}-\d{6}-\d{3}-\d$";

            // Verificar si el NIT coincide con el patrón
            Regex regex = new Regex(pattern);
            return regex.IsMatch(nit);
        }

        //Razon Social
        private static readonly Regex regexRazonSocial = new Regex("^[a-zA-Z0-9 ]{1,100}$");

        public static bool ValidateRazonSocial(string razonSocial)
        {
            bool isValid = regexRazonSocial.IsMatch(razonSocial);

            return isValid;
        }
        //Nombre Empresa
        private static readonly Regex regexNombreEmpresa = new Regex("^[a-zA-Z0-9 ]{1,50}$");

        public static bool ValidateNombreEmpresa(string nombreEmpresa)
        {
            bool isValid = regexNombreEmpresa.IsMatch(nombreEmpresa);

            return isValid;
        }
        //Direccion
        private static readonly Regex regexDireccion = new Regex("^[a-zA-Z0-9,&.áéíóúüÉÁÚÍÓÜñÑ´ ]{1,100}$");

        public static bool ValidateDireccion(string direccion)
        {
            bool isValid = regexDireccion.IsMatch(direccion);

            return isValid;
        }
        #endregion

        #region "Company"
        //NIT
        private static readonly Regex regexNitCompany = new Regex("^(?!.*  )[0-9-]{0,15}$");

        public static bool ValidateNitComp(string nit)
        {
            bool isValid = regexNitCompany.IsMatch(nit);

            return isValid;
        }
        public static bool ValidateSpecificNitComp(string nit)
        {
            // Patrón para validar el formato específico del NIT: XXXX-XXXXXX-XXX-X
            string pattern = @"^\d{4}-\d{6}-\d{3}-\d$";

            // Verificar si el NIT coincide con el patrón
            Regex regex = new Regex(pattern);
            return regex.IsMatch(nit);
        }

        private static readonly Regex regexNameCompany = new Regex("^(?!.*  )[a-zA-Z0-9&.áéíóúüÉÁÚÍÓÜñÑ´ -]{0,50}$");

        public static bool ValidateNameComp(string name)
        {
            // Verificar si el nombre cumple con el patrón de la expresión regular
            bool isValid = regexNameCompany.IsMatch(name);

            return isValid;
        }
        //Telefono
        private static readonly Regex regexPhoneCompany = new Regex(@"^[0-9+-]{0,20}$");
        public static bool ValidatePhoneComp(string phone)
        {
            bool isValid = regexPhoneCompany.IsMatch(phone);

            return isValid;
        }
        //Contacto

        private static readonly Regex regexContactCompany = new Regex(@"^[a-zA-Z0-9.-]{0,60}$");

        public static bool ValidateContactComp(string contact)
        {
            bool isValid = regexContactCompany.IsMatch(contact);

            return isValid;
        }
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
            return text;
        }


    }
}