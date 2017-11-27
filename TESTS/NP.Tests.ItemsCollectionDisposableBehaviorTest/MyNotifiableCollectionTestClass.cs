using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using NP.Paradigms;
using System.Collections.Specialized;
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
