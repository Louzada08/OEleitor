using System.Collections.Generic;

namespace OEleitor.Infra.IoC.IOC
{
    public interface INotifier
    {
        List<Notification> GetNotifications();
        void Handle(Notification notification);
        bool HasNotification();
    }
}
