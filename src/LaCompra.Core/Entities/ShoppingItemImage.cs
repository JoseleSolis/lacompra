namespace LaCompra.Core.Entities;

public sealed class ShoppingItemImage
{
    public int Id { get; set; }
    public int ShoppingItemId { get; set; }
    public string RelativePath { get; set; } = string.Empty;
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    public ShoppingItem ShoppingItem { get; set; } = null!;
}
