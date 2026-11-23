namespace LaCompra.Core.Entities;

public sealed class ShoppingItem
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<ShoppingItemImage> Images { get; set; } = new List<ShoppingItemImage>();
}
