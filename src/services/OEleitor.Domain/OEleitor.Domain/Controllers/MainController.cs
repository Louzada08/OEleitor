using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OEleitor.Domain.Controllers
{
    public abstract class MainController : Controller
    {
        protected readonly NotificationDomainHandler _notifications;
        protected MainController(INotificationHandler<NotificationDomanin> notifications)
        {
            _notifications = (notificationDomainHandler)notifications;
        }
        public new IActionResult Response(object result = null)
        {
            if (OperacaoEhValida())
            {
                if(result != null && result.GetType() == typeof(CommandResult))
                {
                    var commandResult = (commandResult)result;

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