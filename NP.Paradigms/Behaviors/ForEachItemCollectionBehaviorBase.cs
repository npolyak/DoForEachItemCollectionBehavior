// (c) Nick Polyak 2017 - http://awebpros.com/
// License: Code Project Open License (CPOL) 1.92(http://www.codeproject.com/info/cpol10.aspx)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author(s) of this software if something goes wrong. 
// 
// Also as a courtesy, please, mention this software in any documentation for the 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Paradigms.Behaviors
{
    public abstract class ForEachItemCollectionBehaviorBase<T> :
        IStatelessBehavior<IEnumerable<T>>
    {
        protected abstract void UnsetItem(T item);
        protected abstract void SetItem(T item);

        private void UnsetItems(IEnumerable items)
        {
            if (items == null)
                return;

            foreach (T item in items)
            {
                UnsetItem(item);
            }
        }

        private void SetItems(IEnumerable items)
        {
            if (items == null)
                return;

            foreach (T item in items)
            {
                SetItem(item);
            }
        }


        private void Collection_CollectionChanged
        (
            object sender, 
            NotifyCollectionChangedEventArgs e
        )
        {
            UnsetItems(e.OldItems);
            SetItems(e.NewItems);
        }

        public void Detach(IEnumerable<T> collection)
        {
            if (collection == null)
                return;

            INotifyCollectionChanged notifiableCollection =
                collection as INotifyCollectionChanged;

            if (notifiableCollection != null)
            {
                notifiableCollection.CollectionChanged -=
                    Collection_CollectionChanged;
            }

            UnsetItems(collection);
        }

        public void Attach(IEnumerable<T> collection)
        {
            if (collection == null)
                return;

            SetItems(collection);

            INotifyCollectionChanged notifiableCollection =
                collection as INotifyCollectionChanged;

            if (notifiableCollection != null)
            {
                notifiableCollection.CollectionChanged += 
                    Collection_CollectionChanged;
            }
        }
    }
}
