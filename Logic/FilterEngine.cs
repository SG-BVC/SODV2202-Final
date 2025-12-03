using System.Collections.Generic;
using System.Linq;
using SODV2202_Final.Models;

namespace SODV2202_Final.Logic
{
    public static class FilterEngine
    {
        // USER FILTERS
        public static List<User> FilterUsers(List<User> data, string field, string op, string value)
        {
            switch (field)
            {
                case "Name":
                    return data.Where(u => u.Name.ToLower().Contains(value.ToLower())).ToList();

                case "Email":
                    return data.Where(u => u.Email.ToLower().Contains(value.ToLower())).ToList();

                case "Age":
                    int val = int.Parse(value);

                    return op switch
                    {
                        ">=" => data.Where(u => u.Age >= val).ToList(),
                        "<=" => data.Where(u => u.Age <= val).ToList(),
                        ">" => data.Where(u => u.Age > val).ToList(),
                        "<" => data.Where(u => u.Age < val).ToList(),
                        "==" => data.Where(u => u.Age == val).ToList(),
                        _ => data
                    };
            }

            return data;
        }

        // PASSWORD FILTERS
        public static List<PasswordHistory> FilterPasswords(List<PasswordHistory> data, string field, string op, string value)
        {
            switch (field)
            {
                case "Strength":
                    return data.Where(p => p.Strength == value).ToList();

                case "Length":
                    int lengthValue = int.Parse(value);
                    return op switch
                    {
                        ">=" => data.Where(p => p.Length >= lengthValue).ToList(),
                        "<=" => data.Where(p => p.Length <= lengthValue).ToList(),
                        ">" => data.Where(p => p.Length > lengthValue).ToList(),
                        "<" => data.Where(p => p.Length < lengthValue).ToList(),
                        "==" => data.Where(p => p.Length == lengthValue).ToList(),
                        _ => data
                    };

                case "ContainsUppercase":
                    int uc = int.Parse(value);
                    return data.Where(p => p.ContainsUppercase == uc).ToList();

                case "ContainsNumbers":
                    int n = int.Parse(value);
                    return data.Where(p => p.ContainsNumbers == n).ToList();

                case "ContainsSymbols":
                    int s = int.Parse(value);
                    return data.Where(p => p.ContainsSymbols == s).ToList();
            }

            return data;
        }
    }
}
