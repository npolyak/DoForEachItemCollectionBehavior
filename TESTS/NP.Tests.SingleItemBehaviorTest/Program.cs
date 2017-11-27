// (c) Nick Polyak 2017 - http://awebpros.com/
// License: Code Project Open License (CPOL) 1.92(http://www.codeproject.com/info/cpol10.aspx)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author(s) of this software if something goes wrong. 
// 
// Also as a courtesy, please, mention this software in any documentation for the 


namespace NP.Tests.SingleItemBehaviorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the test class
            MyNotifiablePropsTestClass myTestClass = new MyNotifiablePropsTestClass();

            // create the behavior
            PrintNotifiablePropertyBehavior printNotifiablePropertyBehavior = 
                new PrintNotifiablePropertyBehavior();

            // attach the behavior to the class
            printNotifiablePropertyBehavior.Attach(myTestClass);

            // should print (since Behavior is attached)
            myTestClass.TheString = "Hello World";

            // detach the behavior from the class
            printNotifiablePropertyBehavior.Detach(myTestClass);

            // should not print (since Behavior is detached);
            myTestClass.TheString = "Bye World";
        }
    }
}
