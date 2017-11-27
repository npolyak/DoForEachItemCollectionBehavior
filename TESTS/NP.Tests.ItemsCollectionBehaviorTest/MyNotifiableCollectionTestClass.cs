// (c) Nick Polyak 2017 - http://awebpros.com/
// License: Code Project Open License (CPOL) 1.92(http://www.codeproject.com/info/cpol10.aspx)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author(s) of this software if something goes wrong. 
// 
// Also as a courtesy, please, mention this software in any documentation for the 

using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using NP.Paradigms;
using System.Collections.Specialized;
using NP.Paradigms.Behaviors;

namespace NP.Tests.ItemsCollectionBehaviorTest
{
    public class MyNotifiableCollectionTestClass
    {
        // define and create the behavior.
        DoForEachItemCollectionBehavior<INotifyPropertyChanged>
            _doForEachItemCollectionBehavior =
                new DoForEachItemCollectionBehavior<INotifyPropertyChanged>
                (
                    item => item.PropertyChanged += Item_PropertyChanged,
                    item => item.PropertyChanged -= Item_PropertyChanged
                );

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

                // detach from old collection
                _doForEachItemCollectionBehavior.Detach(_collection);

                this._collection = value;

                // attach to new collection
                _doForEachItemCollectionBehavior.Attach(_collection);
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
