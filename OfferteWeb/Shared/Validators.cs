
using System.Text.RegularExpressions;

namespace OfferteWeb.Shared
{
    public class Validators
    {
        public static string DocIdRegEx { get { return "^[a-zA-Z0-9]{0,40}$"; } }
        public static string CityRegEx { get { return @"^[\p{L}-'.,_0-9/\s]{0,30}$"; } }
        public static string StreetRegEx { get { return @"^[\p{L}-'.,_0-9/\s]{0,30}$"; } }
        public static string StreetNumberRegEx { get { return @"^[a-zA-Z0-9 /'-.]{0,8}$"; } }
        public static string CapRegEx { get { return @"^\d{0,5}$"; } }
        public static string NumberOnlyRegEx { get { return @"^\d+$"; } }
        public static string TelephoneRegEx { get { return @"^[+]{0,1}\d+$"; } }
        public static string TaxCodeRegEx { get { return @"^([A-Za-z]{6}[0-9lmnpqrstuvLMNPQRSTUV]{2}[abcdehlmprstABCDEHLMPRST]{1}[0-9lmnpqrstuvLMNPQRSTUV]{2}[A-Za-z]{1}[0-9lmnpqrstuvLMNPQRSTUV]{3}[A-Za-z]{1})$|([0-9]{11})$"; } }
        public static string TaxCodeRegExOrEmpty { get { return @"^$|([A-Za-z]{6}[0-9lmnpqrstuvLMNPQRSTUV]{2}[abcdehlmprstABCDEHLMPRST]{1}[0-9lmnpqrstuvLMNPQRSTUV]{2}[A-Za-z]{1}[0-9lmnpqrstuvLMNPQRSTUV]{3}[A-Za-z]{1})$|([0-9]{11})$"; } }

        public static string AplhabeticRegex { get { return @"/^[a-zA-Z\s]*$/"; } }


        public IEnumerable<string> AlphabetValidator(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                yield return "Inserire un testo";
                yield break;
            }

            if (Regex.IsMatch(nome, @"/^[a-z ,.'-]+$/i"))
                yield return "Inserire solo valori alfabetici";
        }

        public IEnumerable<string> AlphabetValidatorOnlyString(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome) && Regex.IsMatch(nome, @"/^[a-z ,.'-]+$/i"))
                yield return "Inserire solo valori alfabetici";
        }


        public IEnumerable<string> TaxCodeValidator(string cf)
        {
            if (string.IsNullOrWhiteSpace(cf))
            {
                yield return "Necessario inserire Codice Fiscale";
                yield break;
            }
            if (cf.Length < 16)
                yield return "Codice fiscale deve avere almeno 16 caratteri";
            if (!Regex.IsMatch(cf, @"^([A-Za-z]{6}[0-9lmnpqrstuvLMNPQRSTUV]{2}[abcdehlmprstABCDEHLMPRST]{1}[0-9lmnpqrstuvLMNPQRSTUV]{2}[A-Za-z]{1}[0-9lmnpqrstuvLMNPQRSTUV]{3}[A-Za-z]{1})$|([0-9]{11})$"))
                yield return "Errore nell'inserimento di caratteri all'interno del codice fiscale";

        }


        public IEnumerable<string> MailValidator(string mail)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(mail))
            {
                yield return "Inserire mail";
                yield break;
            }
            try
            {
                var address = new System.Net.Mail.MailAddress(mail).Address;
                isValid = true;
            }
            catch (FormatException)
            {
                isValid = false;
            }

            if (!isValid)
                yield return "Mail non corretta!";

            //if (!Regex.IsMatch(mail, @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$"))
            //    yield return "Mail non corretta!";
        }

        public IEnumerable<string> OnlyNumberValidator(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                yield return "Inserire numero";
                yield break;
            }

            if (!Regex.IsMatch(number, @"^[0-9\s]*$"))
                yield return "Numero non corretto!";
        }

        public IEnumerable<string> OnlyNumberValidatorTelLavoro(string number)
        {
            if (!Regex.IsMatch(number, @"^[0-9\s]*$"))
                yield return "Numero non corretto!";
        }
    }
}
