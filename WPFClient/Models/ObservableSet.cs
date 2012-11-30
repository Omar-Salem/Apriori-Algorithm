using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPFClient
{
    public class ObservableSet<T> : ObservableCollection<T>
    {
        readonly HashSet<T> _items;

        public ObservableSet()
        {
            _items = new HashSet<T>();
        }

        protected override void InsertItem(int index, T item)
        {
            if (!_items.Contains(item))
            {
                base.InsertItem(index, item);
                _items.Add(item);
            }
        }

        protected override void RemoveItem(int index)
        {
            T item = base[index];
            _items.Remove(item);
            base.RemoveItem(index);
        }
    }
}
