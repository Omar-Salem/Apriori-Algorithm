using System;
namespace AprioriAlgorithm
{
    public class Item : IComparable<Item>
    {
        #region Public Properties

        public string Name { get; set; }
        public double Support { get; set; } 

        #endregion

        #region IComparable

        public int CompareTo(Item other)
        {
            return Name.CompareTo(other.Name);
        } 

        #endregion
    }
}