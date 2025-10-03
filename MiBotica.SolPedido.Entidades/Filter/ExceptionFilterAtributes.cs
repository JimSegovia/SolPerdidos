using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
namespace MiBotica.SolPedido.Entidades.Filter
{
    //controla los errores y mantiene un log de los mismos

    public class ExceptionFilterAtributes : FilterAttribute, IExceptionFilter
    {
        public ILog Log
        {
            get
            {
                return LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod()
                .GetType());
            }
        }

        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 500;
            Log.Error(filterContext.Exception);
        }
    }
}