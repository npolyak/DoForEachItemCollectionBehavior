using NP.Paradigms.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Tests.SimpleStatelessBehaviorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTestClass myTestClass = new MyTestClass();

            PrintNotifiablePropertyBehavior printNotifiablePropertyBehavior = 
                new PrintNotifiablePropertyBehavior();



            printNotifiablePropertyBehavior.Attach(myTestClass);

            // should print (since Behavior is attached)
            myTestClass.TheString = "Hello World";

            printNotifiablePropertyBehavior.Detach(myTestClass);

            // should not print (since Behavior is detached);
            myTestClass.TheString = "Bye World";
        }
    }
}
