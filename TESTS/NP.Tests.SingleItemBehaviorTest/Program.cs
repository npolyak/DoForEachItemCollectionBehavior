
namespace NP.Tests.SingleItemBehaviorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyNotifiablePropsTestClass myTestClass = new MyNotifiablePropsTestClass();

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
