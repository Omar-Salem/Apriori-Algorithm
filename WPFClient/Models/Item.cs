namespace WPFClient
{
    public class Item
    {
        public char Name { get; set; }

        public bool Selected { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Item;

            if (other == null)
            {
                return false;
            }

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}