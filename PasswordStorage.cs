using System.Collections.Generic;

namespace SODV2202_Final
{
    public class PasswordStorage
    {
        private readonly List<string> _passwords = new();

        public void SavePassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                _passwords.Add(password);
            }
        }

        public List<string> GetAllPasswords()
        {
            return _passwords;
        }
    }
}
