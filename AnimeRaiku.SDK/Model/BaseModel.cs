using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model
{
    public abstract class BaseModel
    {
        public String GetModelName() => this.GetType().Name;
    }
}
