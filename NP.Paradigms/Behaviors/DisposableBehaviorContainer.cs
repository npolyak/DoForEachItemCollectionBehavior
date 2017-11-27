// (c) Nick Polyak 2017 - http://awebpros.com/
// License: Code Project Open License (CPOL) 1.92(http://www.codeproject.com/info/cpol10.aspx)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author(s) of this software if something goes wrong. 
// 
// Also as a courtesy, please, mention this software in any documentation for the using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Paradigms.Behaviors
{
    public class DisposableBehaviorContainer<T> : IDisposable
    {
        public IStatelessBehavior<T> TheBehavior { get; }
        public T TheObjectTheBehaviorIsAttachedTo { get; }

        public DisposableBehaviorContainer
        (
            IStatelessBehavior<T> behavior,
            T objectTheBehaviorIsAttachedTo
        )
        {
            TheBehavior = behavior;
            TheObjectTheBehaviorIsAttachedTo = objectTheBehaviorIsAttachedTo;

            TheBehavior.Attach(TheObjectTheBehaviorIsAttachedTo);
        }

        public void Dispose()
        {
            TheBehavior?.Detach(TheObjectTheBehaviorIsAttachedTo);
        }
    }
}
