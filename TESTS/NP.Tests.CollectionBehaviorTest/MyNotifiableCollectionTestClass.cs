using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using NP.Paradigms;
using System.Collections.Specialized;

namespace NP.Tests.CollectionBehaviorTest
{
    public class MyNotifiableCollectionTestClass 
    {
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

                if (_collection != null)
                {
                    _collection.CollectionChanged -=
                        _collection_CollectionChanged;
                }

                UnsetItems(this._collection);

                this._collection = value;

                SetItems(this._collection);

                if (_collection != null)
                {
                    _collection.CollectionChanged +=
                        _collection_CollectionChanged;
                }
            }
        }

        private void _collection_CollectionChanged
        (
            object sender, 
            NotifyCollectionChangedEventArgs e
        )
        {
            UnsetItems(e.OldItems);
            SetItems(e.NewItems);
        }
        #endregion TheCollection Property

        void UnsetItems(IEnumerable items)
        {
            if (items == null)
                return;

            foreach (MyNotifiablePropsTestClass item in items)
            {
                item.PropertyChanged -= Item_PropertyChanged;
            }
        }

        void SetItems(IEnumerable items)
        {
            if (items == null)
                return;

            foreach(MyNotifiablePropsTestClass item in items)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            sender.PrintPropValue(e.PropertyName);
        }
    }
}
