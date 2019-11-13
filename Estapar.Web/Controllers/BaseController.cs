using Estapar.Web.Notification;
using System.Web.Mvc;

namespace Estapar.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            var exception = filterContext.Exception;
            if (exception != null)
            {
                this.AddNotification(exception.Message, NotificationType.ERROR);
            }
        }

        protected void SetNotifications()
        {
            foreach (var item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    foreach (var error in item.Errors)
                    {
                        this.AddNotification(error.ErrorMessage, NotificationType.ERROR);
                    }
                }
            }
        }
    }
}