using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Paradigms.Behaviors
{
    public interface IStatelessBehavior<T>
    {
        void Attach(T obj);

        void Detach(T obj);
    }
}
