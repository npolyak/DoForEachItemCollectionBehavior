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

namespace NP.Tests.ItemsCollectionTest
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
                    // remove the handler
                    // from the old collection
                    _collection.CollectionChanged -=
                        _collection_CollectionChanged;
                }

                // remove handlers from items 
                // in the old collection
                UnsetItems(this._collection);

                this._collection = value;

                // add handlers to the items 
                // in the new collection
                SetItems(this._collection);

                if (_collection != null)
                {
                    // watch for the new collection change
                    // to set the added and unset
                    // the removed items
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
            // remove handlers from the old items
            UnsetItems(e.OldItems);

            // add handlers to all new items
            SetItems(e.NewItems);
        }
        #endregion TheCollection Property

        // removes the PropertyChanged handler from all
        // old items
        void UnsetItems(IEnumerable items)
        {
            if (items == null)
                return;

            foreach (MyNotifiablePropsTestClass item in items)
            {
                item.PropertyChanged -= Item_PropertyChanged;
            }
        }

        // attached the PropertyChanged handler to all 
        // new items
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
            // prints the property name and value to console
            sender.PrintPropValue(e.PropertyName);
        }
    }
}
