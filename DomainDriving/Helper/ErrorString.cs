using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriving.Helper
{
    public static class ErrorString
    {
        public static string CollectError<T>(IEnumerable<T> errors)
        {
            StringBuilder errorInfo = new StringBuilder();
            foreach (var error in errors)
            {
                errorInfo.Append(error);
                errorInfo.Append("\n");
            }
            return errorInfo.ToString();
        }
    }
}
