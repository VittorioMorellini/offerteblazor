using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfferteWeb.Utils
{
    public class ServiceResult
    {
        public static ActionResult Execute(Action action)
        {
            try
            {
                action.Invoke();
                return new OkObjectResult("OK");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public static ActionResult Execute<T>(Func<T> func)
        {
            try
            {
                return new OkObjectResult(func.Invoke());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.InnerException!=null ? ex.InnerException.Message : ex.Message);
            }
        }

        public static ActionResult ExecuteAsync<T>(Func<Task<T>> func)
        {
            try
            {
                var task = func.Invoke();
                task.Wait();

                if (task.IsCompletedSuccessfully)
                    return new OkObjectResult(task.Result);
                else
                    return new BadRequestObjectResult(task.Result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
