using NP.Paradigms;
using NP.Paradigms.Behaviors;
using System;
using System.ComponentModel;
using System.Reflection;

namespace NP.Tests.SingleItemBehaviorTest
{
    public class PrintNotifiablePropertyBehavior :
        IStatelessBehavior<INotifyPropertyChanged>
    {
        // the handler
        private static void NotifyiableObject_PropertyChanged
        (
            object sender, 
            PropertyChangedEventArgs e
        )
        {
            // pring property name and value to the console
            // using reflection
            sender.PrintPropValue(e.PropertyName);
        }

        public void Attach(INotifyPropertyChanged notifyiableObject)
        {
            // add the handler
            notifyiableObject.PropertyChanged +=
                NotifyiableObject_PropertyChanged;
        }

        public void Detach(INotifyPropertyChanged notifyiableObject)
        {
            // remove the handler
            notifyiableObject.PropertyChanged -= 
                NotifyiableObject_PropertyChanged;
        }
    }
}
