using NP.Paradigms.Behaviors;
using System;
using System.ComponentModel;
using System.Reflection;

namespace NP.Tests.SimpleStatelessBehaviorTest
{
    public class PrintNotifiablePropertyBehavior : IStatelessBehavior<INotifyPropertyChanged>
    {
        private void NotifyiableObject_PropertyChanged
        (
            object sender, 
            PropertyChangedEventArgs e
        )
        {
            PropertyInfo changedPropertyInfo = 
                sender
                    .GetType()
                    .GetProperty(e.PropertyName);

            object propValue = changedPropertyInfo?.GetValue(sender);

            Console.WriteLine(e.PropertyName + ": " + propValue?.ToString());
        }

        public void Attach(INotifyPropertyChanged notifyiableObject)
        {
            notifyiableObject.PropertyChanged += NotifyiableObject_PropertyChanged;
        }

        public void Detach(INotifyPropertyChanged notifyiableObject)
        {
            notifyiableObject.PropertyChanged -= NotifyiableObject_PropertyChanged;
        }
    }
}
