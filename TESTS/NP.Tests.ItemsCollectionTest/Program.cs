
using System.Collections.ObjectModel;

namespace NP.Tests.ItemsCollectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the observable collection containing class
            MyNotifiableCollectionTestClass collectionTestClass = 
                new MyNotifiableCollectionTestClass();

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
    }
}
