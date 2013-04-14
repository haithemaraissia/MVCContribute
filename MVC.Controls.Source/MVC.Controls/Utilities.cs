using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Reflection;

namespace MVC.Controls
{
    public static class Utilities
    {
        /// <summary>
        /// Serializes the specified model object to a GET querystring parameter
        /// Note: The serialization is shallow, meaning only first level properties are serialized
        /// </summary>
        /// <param name="html"></param>
        /// <param name="model">The model object to serialize</param>
        /// <param name="parameterName">The parameter name of the Controller method</param>
        /// <returns></returns>
        public static string BuildQuery(this HtmlHelper html, object model, string parameterName)
        {

            PropertyInfo[] props = model.GetType().GetProperties();
            StringBuilder sb = new StringBuilder();
            sb.Append("?");
            bool isFirst = true;

            foreach (PropertyInfo prop in props)
            {
                object val = prop.GetValue(model, null);
                if (val != null)
                {
                    if (isFirst) isFirst = false;
                    else sb.Append("&");
                    sb.AppendFormat("{0}.{1}={2}", parameterName, prop.Name, val);
                }
            }

            return sb.ToString();
        }
    }
}
