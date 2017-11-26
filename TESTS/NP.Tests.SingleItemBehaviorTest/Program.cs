
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
