
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
            MyNotifiableCollectionTestClass collectionTestClass = 
                new MyNotifiableCollectionTestClass();

            collectionTestClass.TheCollectionChangedEvent += CollectionTestClass_TheCollectionChangedEvent;

            MyNotifiablePropsTestClass item1 = new MyNotifiablePropsTestClass();

            // create collection containing item1.
            collectionTestClass.TheCollection = 
                new ObservableCollection<MyNotifiablePropsTestClass>
                (
                    new MyNotifiablePropsTestClass[] { item1 }
                );


            // verify that item1 is notifiable (should print to console): 
            item1.TheString = "Item1: Hello World";

            MyNotifiablePropsTestClass item2 = new MyNotifiablePropsTestClass();

            // add to collection
            collectionTestClass.TheCollection.Add(item2);

            // verify that notifiable (should print)
            item2.TheString = "Item2: Hello World";

            // remove item2
            collectionTestClass.TheCollection.RemoveAt(1);

            // verify that it is not notifiable any longer
            // (should not print)
            item2.TheString = "Item2: Bye Wordl";

            // disconnect the whole collection (i.e. Item1)
            collectionTestClass.TheCollection = null;

            // should not print
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
