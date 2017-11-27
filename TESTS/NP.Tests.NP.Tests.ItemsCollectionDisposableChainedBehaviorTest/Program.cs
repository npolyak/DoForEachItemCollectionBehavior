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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NP.Tests.ItemsCollectionDisposableChainedBehaviorTest
{
    class Program
    {
        static void Main(string[] args)
        {            
            // create the observable collection containing class
            MyNotifiableCollectionTestClass collectionTestClass = 
                new MyNotifiableCollectionTestClass();

            // create the handler for event fired when TheCollection
            // property is assigned a new value
            collectionTestClass.TheCollectionChangedEvent += 
                CollectionTestClass_TheCollectionChangedEvent;

            // create item 1.
            MyNotifiablePropsTestClass item1 = new MyNotifiablePropsTestClass();

            // set TheCollection property of the collection
            // containing class to be an ObservableCollection
            // that contains item1
            collectionTestClass.TheCollection =
                new ObservableCollection<MyNotifiablePropsTestClass>
                (
                    new MyNotifiablePropsTestClass[] { item1 }
                );

            // change item1.TheString
            // since item1 is part of the collection,
            // it should print to console: 
            item1.TheString = "Item1: Hello World";

            // create item2
            MyNotifiablePropsTestClass item2 = new MyNotifiablePropsTestClass();

            // add item2 to the collection
            collectionTestClass.TheCollection.Add(item2);

            // change item2.TheString
            // since item2 is part of the collection,
            // it should print to console
            item2.TheString = "Item2: Hello World";

            // remove item2 from collection
            collectionTestClass.TheCollection.RemoveAt(1);

            // since item2 is no longer
            // part of the collection
            // should NOT print to console
            item2.TheString = "Item2: Bye Wordl";

            // disconnect the whole collection (i.e. Item1)
            collectionTestClass.TheCollection = null;

            // since the collection property is null,
            // nothing should be printed to console
            // when Item1.TheString is changed.
            item1.TheString = "Item1: Bye World";
        }

        static IDisposable _disposableBehaviors = null;
        private static void CollectionTestClass_TheCollectionChangedEvent
        (
            ObservableCollection<MyNotifiablePropsTestClass> collection
        )
        {
            _disposableBehaviors?.Dispose();

            _disposableBehaviors = collection
                .AddBehavior
                (
                    item => item.PropertyChanged += Item_PropertyChanged,
                    item => item.PropertyChanged -= Item_PropertyChanged
                )
                .AddBehavior
                (
                    item => NumberItemsInCollection++,
                    item => NumberItemsInCollection--
                );
        }

        static int _numberItemsInCollection = 0;
        public static int NumberItemsInCollection
        {
            get
            {
                return _numberItemsInCollection;
            }
            set
            {
                if (_numberItemsInCollection == value)
                    return;

                _numberItemsInCollection = value;

                Console.WriteLine($"Number items in collection: {_numberItemsInCollection}");
            }
        }

        private static void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            sender.PrintPropValue(e.PropertyName);
        }
    }
}
