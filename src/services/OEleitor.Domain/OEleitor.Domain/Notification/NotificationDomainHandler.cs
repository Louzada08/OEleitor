using MediatR;
using System;
using System.Collections.Generic;

namespace OEleitor.Domain.Notification
{
    public class NotificationDomainHandler : INotificationHandler<NotificationDomain>
    {
        private List<NotificationDomain> _notifications;

        public NotificationDomainHandler()
        {
            _notifications = new List<NotificationDomain>();
        }


        public void Dispose()
        {
            _notifications = new List<NotificationDomain>();
        }
    }
}
