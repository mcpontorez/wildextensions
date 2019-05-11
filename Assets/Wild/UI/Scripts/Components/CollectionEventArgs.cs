using System;

namespace Wild.UI.Components
{
    public class CollectionItemEventArgs<TItem> : EventArgs
    {
        public TItem Item { get; set; }
        public int Index { get; set; }

        public CollectionItemEventArgs() { }
        public CollectionItemEventArgs(TItem item, int index)
        {
            Item = item;
            Index = index;
        }

        public override string ToString()
        {
            return base.ToString() + " {\"" + nameof(Index) + "\":" + Index +"} ";
        }
    }
}
