// (c) Nick Polyak 2017 - http://awebpros.com/
// License: Code Project Open License (CPOL) 1.92(http://www.codeproject.com/info/cpol10.aspx)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author(s) of this software if something goes wrong. 
// 
// Also as a courtesy, please, mention this software in any documentation for the 

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
