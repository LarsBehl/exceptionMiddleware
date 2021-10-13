namespace ExceptionMiddleware.Model
{
    public class ErrorResponse
    {
        public string Title { get; set; }
        public string DetailMessage { get; set; }
        public int ErrorCode { get; set; }
    }
}