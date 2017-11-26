using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NP.Paradigms.Behaviors
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
