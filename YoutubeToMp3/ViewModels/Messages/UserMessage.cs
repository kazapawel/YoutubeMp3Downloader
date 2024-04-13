using System.Text;

namespace YoutubeToMp3
{
    public abstract class UserMessage
    {
        public StringBuilder Message { get; set; }

        public UserMessage(string message)
        {
            Message = new StringBuilder();
            Message.AppendLine(message);
        }

        public virtual void AppendSecondaryInfo(string message)
        {
            Message.AppendLine(message);
        }

        public override string ToString()
        {
            return Message.ToString();
        }
    }
}
