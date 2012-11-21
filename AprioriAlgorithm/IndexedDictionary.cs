using System.Collections.ObjectModel;

namespace AprioriAlgorithm
{
    public class ItemsDictionary : KeyedCollection<string, Item>
    {
        protected override string GetKeyForItem(Item item)
        {
            return item.Name;
        }
    }
}