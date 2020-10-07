using System.Collections.Generic;
using Ubus.Business.Notifications;

namespace Ubus.Business.Interfaces.Notifications
{
    public interface INotifier
    {
        bool HasNotification();
        List<NotificationBase> GetNotifications();
        void Handle(NotificationBase notification);
    }
}
