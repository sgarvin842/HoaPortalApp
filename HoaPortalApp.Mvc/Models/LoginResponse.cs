namespace HoaPortalApp.Mvc.Models
{
    public class LoginResponse
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string token { get; set; }
    }
}
