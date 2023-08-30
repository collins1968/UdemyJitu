namespace UdemyJitu.Responses
{
    public class SuccessMessage
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public SuccessMessage(int c, string m)
        {
            c = Code;
            m = Message;
        }

    }
}
