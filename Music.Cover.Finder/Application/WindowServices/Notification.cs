namespace Music.Cover.Finder.Application.WindowServices
{
    public class Notification
    {
        public string Type { get; }
        public string Title { get; }
        public string Content { get; }

        private Notification(NotificationType type, string title, string message)
        {
            Type = type.ToString().ToLower();
            Title = title;
            Content = message;
        }

        public static Notification Error(string title, string message)
        {
            return new Notification(NotificationType.Error, title, message);
        }
    }
}
