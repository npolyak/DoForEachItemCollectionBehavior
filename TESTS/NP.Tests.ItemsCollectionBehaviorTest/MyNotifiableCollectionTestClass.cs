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
