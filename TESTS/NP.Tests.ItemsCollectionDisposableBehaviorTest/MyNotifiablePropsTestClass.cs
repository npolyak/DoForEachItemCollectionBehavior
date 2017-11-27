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
