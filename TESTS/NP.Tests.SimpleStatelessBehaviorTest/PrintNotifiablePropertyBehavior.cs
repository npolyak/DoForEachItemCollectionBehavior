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
        private void NotifyiableObject_PropertyChanged
        (
            object sender, 
            PropertyChangedEventArgs e
        )
        {
            sender.PrintPropValue(e.PropertyName);
        }

        public void Attach(INotifyPropertyChanged notifyiableObject)
        {
            notifyiableObject.PropertyChanged +=
                NotifyiableObject_PropertyChanged;
        }

        public void Detach(INotifyPropertyChanged notifyiableObject)
        {
            notifyiableObject.PropertyChanged -= 
                NotifyiableObject_PropertyChanged;
        }
    }
}
