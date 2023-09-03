namespace Jitu_Udemy.Responses
{
    public class ResponseMessage
    {
        public int code { get; set; }

        public string Message { get; set; }

        public ResponseMessage(int code, string message)
        {
            this.code = code;
            this.Message = message;
        }

    }
}
