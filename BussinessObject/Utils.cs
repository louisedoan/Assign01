using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public static class Utils
    {
        public static bool isNotEmpty(String value)
        {
            return (value != null && value.Length > 0);
        }
    }
}
