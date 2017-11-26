
using System.Collections.ObjectModel;

namespace NP.Tests.ItemsCollectionDisposableBehaviorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyNotifiableCollectionTestClass collectionTestClass = 
                new MyNotifiableCollectionTestClass();

            MyNotifiablePropsTestClass item1 = new MyNotifiablePropsTestClass();

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
    }
}
