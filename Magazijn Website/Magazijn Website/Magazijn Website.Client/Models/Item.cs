namespace Magazijn_Website.Client.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsBorrowed { get; set; }
    }
}
