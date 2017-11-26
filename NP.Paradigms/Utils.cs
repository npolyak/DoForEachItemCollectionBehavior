using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NP.Paradigms
{
    public static class Utils
    {
        public static void PrintPropValue(this object obj, string propName)
        {
            PropertyInfo changedPropertyInfo =
                obj.GetType()
                   .GetProperty(propName);

            object propValue =
                changedPropertyInfo?.GetValue(obj);

            Console.WriteLine
            (
                propName + ": " + propValue?.ToString()
            );
        }
    }
}
