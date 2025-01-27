namespace Domain.DomainModels
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ShoppingListItem> ShoppingLists { get; set; } = new List<ShoppingListItem>();  // Item can be in multiple shopping lists
    }
}
