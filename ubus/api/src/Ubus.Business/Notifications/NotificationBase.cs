namespace Ubus.Business.Notifications
{
    public class NotificationBase
    {
        public NotificationBase(string msg)
        {
            Message = msg;
        }

        public string Message { get; }
    }
}
