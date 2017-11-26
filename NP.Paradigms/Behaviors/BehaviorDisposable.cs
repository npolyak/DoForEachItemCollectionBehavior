using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Paradigms.Behaviors
{
    public class BehaviorsDisposable<T> : IDisposable
    {
        List<DisposableBehaviorContainer<T>> _disposableBehaviors = new List<DisposableBehaviorContainer<T>>();


        public T TheObjectTheBehaviorsAreAttachedTo =>
            _disposableBehaviors.LastOrDefault().TheObjectTheBehaviorIsAttachedTo;

        public BehaviorsDisposable
        (
            DisposableBehaviorContainer<T> disposableBehaviorToAdd,
            BehaviorsDisposable<T> previousBehavior = null
        )
        {
            if (previousBehavior != null)
            {
                previousBehavior
                    ._disposableBehaviors
                    ?.ForEach((dispBehavior) => _disposableBehaviors.Add(dispBehavior));
            }

            _disposableBehaviors.Add(disposableBehaviorToAdd);
        }

        public void Dispose()
        {
            foreach (DisposableBehaviorContainer<T> behaviorContainer in _disposableBehaviors)
            {
                behaviorContainer.Dispose();
            }
        }
    }
}
