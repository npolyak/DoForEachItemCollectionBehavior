// (c) Nick Polyak 2017 - http://awebpros.com/
// License: Code Project Open License (CPOL) 1.92(http://www.codeproject.com/info/cpol10.aspx)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author(s) of this software if something goes wrong. 
// 
// Also as a courtesy, please, mention this software in any documentation for the 

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
