using System.Text;

namespace MoneyManager
{
    class Encryption
    {
        const string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        readonly string letters;

        public Encryption(string alphabet = null)
        {
            letters = string.IsNullOrEmpty(alphabet) ? defaultAlphabet : alphabet;
        }

        private static string GetRepeatKey(string s, int n)
        {
            var p = new StringBuilder(s);
            while (p.Length < n)
            {
                p.Append(p);
            }
            return p.ToString(0, n);
        }

        private string Vigenere(string text, string password, bool encrypting = true)
        {
            var gamma = GetRepeatKey(password, text.Length);
            var retValue = new StringBuilder();
            var q = letters.Length;

            for (var i = 0; i < text.Length; i++)
            {
                var letterIndex = letters.IndexOf(text[i]);
                var codeIndex = letters.IndexOf(gamma[i]);
                if (letterIndex < 0)
                {
                    retValue.Append(text[i].ToString());
                }
                else
                {
                    retValue.Append(letters[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString());
                }
            }

            return retValue.ToString();
        }

        public string Encrypt(string plainMessage, string password)
            => Vigenere(plainMessage.ToUpper(), password.ToUpper());

        public string Decrypt(string encryptedMessage, string password)
            => Vigenere(encryptedMessage, password, false);
    }
}
