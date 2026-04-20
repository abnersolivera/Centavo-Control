using System.Collections.Generic;

namespace CentavoControl.Domain.Notifications
{
    public class Notification
    {
        public string Message { get; }
        public Notification(string message)
        {
            Message = message;
        }
    }

    public class Notifiable
    {
        private readonly List<Notification> _notifications = new();
        public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();
        public bool IsValid => _notifications.Count == 0;
        public void AddNotification(string message) => _notifications.Add(new Notification(message));
    }
}
