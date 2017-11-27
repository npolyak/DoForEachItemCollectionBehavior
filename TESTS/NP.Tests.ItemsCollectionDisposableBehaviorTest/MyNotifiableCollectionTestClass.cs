// (c) Nick Polyak 2017 - http://awebpros.com/
// License: Code Project Open License (CPOL) 1.92(http://www.codeproject.com/info/cpol10.aspx)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author(s) of this software if something goes wrong. 
// 
// Also as a courtesy, please, mention this software in any documentation for the 

using System.Collections.ObjectModel;
using System.ComponentModel;
using NP.Paradigms;
using NP.Paradigms.Behaviors;
using System;

namespace NP.Tests.ItemsCollectionDisposableBehaviorTest
{
    public class MyNotifiableCollectionTestClass
    {
        // Contains the disposable token.
        // Calling its Dispose() method will 
        // Detach all the behaviors from the collection
        IDisposable _disposableBehaviors;

        #region TheCollection Property
        private ObservableCollection<MyNotifiablePropsTestClass> _collection;
        public ObservableCollection<MyNotifiablePropsTestClass> TheCollection
        {
            get
            {
                return this._collection;
            }
            set
            {
                if (this._collection == value)
                {
                    return;
                }

                this._collection = value;


                _disposableBehaviors?.Dispose(); // detaches old behaviors
                _disposableBehaviors = _collection.AddBehavior
                (
                    item => item.PropertyChanged += Item_PropertyChanged,
                    item => item.PropertyChanged -= Item_PropertyChanged
                );
            }
        }
        #endregion

        private static void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // prints the property name and value to console
            sender.PrintPropValue(e.PropertyName);
        }
    }
}
