namespace SODV2202_Final.Models
{
    public class PasswordHistory
    {
        public int PasswordId { get; set; }
        public int UserId { get; set; }
        public string PasswordValue { get; set; }
        public string Strength { get; set; }
        public int Length { get; set; }
        public int ContainsUppercase { get; set; }
        public int ContainsNumbers { get; set; }
        public int ContainsSymbols { get; set; }
        public string CreatedAt { get; set; }
    }
}
