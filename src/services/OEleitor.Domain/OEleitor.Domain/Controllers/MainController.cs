using MediatR;
using Microsoft.AspNetCore.Mvc;
using OEleitor.Domain.Message;
using OEleitor.Domain.Notification;

namespace OEleitor.Domain.Controllers
{
    public abstract class MainController : Controller
    {
        protected readonly NotificationDomainHandler _notifications;
        protected MainController(INotificationHandler<NotificationDomain> notifications)
        {
            _notifications = (NotificationDomainHandler)notifications;
        }

        public new IActionResult Response(object result = null)
        {
            if (OperacaoEhValida())
            {
                if(result != null && result.GetType() == typeof(CommandResult))
                {
                    var commandResult = (CommandResult)result;

                    if (commandResult.Data is not null)
                        return Created("", commandResult.Data);
                    else
                        return NoContent();
                }
                else
                {
                    if (result is null)
                        return NotFound();
                    else
                    {
                        return Ok(result);
                    }
                }
            }
            else
            {
                return BadRequest(new CommandResult(_notifications.GetNotifications()));
            }
        }

        protected bool OperacaoEhValida()
        {
            return (!_notifications.HasNotifications());
        }
    }
}