using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Controls.Examples.Controllers.MasterDetail
{
    public abstract class BaseController<TEntityType, TIdType> : ContextGridController<Context, TEntityType, TIdType>
        where TEntityType : class    
    {
        protected override Context CreateContext()
        {
            return Context.Singleton;
        }
    }
}