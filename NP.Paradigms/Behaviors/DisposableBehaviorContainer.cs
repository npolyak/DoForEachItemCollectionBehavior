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
