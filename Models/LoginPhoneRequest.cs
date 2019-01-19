namespace Models
{
    public class LoginPhoneRequest
    {
        public string MobilePhoneNumber { get; set; }
        public string Pin { get; set; }
        public string Language { get; set; }
        public string Username { get; set; }
        public string System { get; set; }
    }
}