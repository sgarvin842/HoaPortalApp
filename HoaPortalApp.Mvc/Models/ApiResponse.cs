namespace HoaPortalApp.Mvc.Models
{   public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public object Meta { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}