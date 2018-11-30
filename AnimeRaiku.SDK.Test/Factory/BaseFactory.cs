using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Test.Factory
{
    public abstract class BaseFactory<T>
    {
        public abstract T Create();

    }
}
