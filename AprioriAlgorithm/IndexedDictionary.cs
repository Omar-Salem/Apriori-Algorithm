using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace AprioriAlgorithm
{
    public class ItemsDictionary : KeyedCollection<string, Item>
    {
        protected override string GetKeyForItem(Item item)
        {
            return item.Name;
        }

        internal void ConcatItems(IList<Item> frequentItems)
        {
            foreach (var item in frequentItems)
            {
                this.Add(item);
            }
        }
    }
}