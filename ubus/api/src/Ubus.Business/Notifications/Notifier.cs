using System;
using System.Collections.Generic;
using System.Linq;
using Ubus.Business.Interfaces.Notifications;
using Ubus.Business.Notifications;

namespace Ubus.Business.Notification
{
    public class Notifier : INotifier
    {
        public List<NotificationBase> _notifications { get; set; }

        public Notifier()
        {
            _notifications = new List<NotificationBase>();
        }

        public void Handle(NotificationBase notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public List<NotificationBase> GetNotifications()
        {
            return _notifications;
        }

    }
}
