using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinksForm.DAL;
using LinksForm.Forms;
using LinksForm.Model;
using System.Reflection;

namespace LinksForm.Controller
{
    public class Validation
    {
        #region Assembly Attribute Accessors

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
        public static bool ContactDataValidation(string Id, string Name, string Phone)
        {
            bool IsEmpty = false;

            if ((Id == string.Empty) || (Name == string.Empty) || (Phone == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static bool AppLinkDataValidation(string cmbCountries, string cmbApplication, string cmbCategory, string Description, string Link, string CredendialUsername)
        {
            bool IsEmpty = false;

            if ((cmbCountries == string.Empty) || (cmbApplication == string.Empty) || (cmbCategory == string.Empty) || (Description == string.Empty) || (Link == string.Empty) || (CredendialUsername == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static bool CredentialDataValidation(string Username, string Password)
        {
            bool IsEmpty = false;

            if ((Username == string.Empty) || (Password == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static bool SubDealerDataValidation(string DealerCode, string DealerName, string comboCountries, string comboDealers)
        {
            bool IsEmpty = false;

            if ((DealerCode == string.Empty) || (DealerName == string.Empty) || (comboCountries == string.Empty) || (comboDealers == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static bool DealerDataValidation(string DealerCode, string DealerName, string comboCountries)
        {
            bool IsEmpty = false;

            if ((DealerCode == string.Empty) || (DealerName == string.Empty) || (comboCountries == string.Empty))
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
        public static string RemoveDiacritics(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                              UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC);
        }
        public static int GetCountryFlagId(string country)
        {

            switch (country)
            {
                case "Brazil":
                    return 1;
                case "Peru":
                    return 4;
                case "Colombia":
                    return 3;
                case "Chile":
                    return 2;
                case "Argentina":
                    return 0;
            };
            //Default
            return 13;
        }
    }
}
