using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Tests.ItemsCollectionDisposableBehaviorTest
{
    public class MyNotifiablePropsTestClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke
            (
                this, 
                new PropertyChangedEventArgs(propName)
            );
        }

        #region TheString Property
        private string _str;
        public string TheString
        {
            get
            {
                return this._str;
            }
            set
            {
                if (this._str == value)
                {
                    return;
                }

                this._str = value;
                this.OnPropertyChanged(nameof(TheString));
            }
        }
        #endregion TheString Property
    }
}
