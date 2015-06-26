using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameEngine2d.Content
{
    class Asset<T>
    {
        protected string assetPath;
        protected T theAsset;
        public T TheAsset
        {
            get { if (IsLoaded) return theAsset; else return default(T); }
            protected set { theAsset = value; }
        }
        public bool IsLoaded { get; private set; }

        public virtual void Load()
        {
            IsLoaded = true;
        }
    }
}
