namespace YoutubeToMp3
{
    public abstract class UserMessage
    {
        public string Message { get; set; }

        public UserMessage(string message)
        {
            Message = message;
        }
    }
}
