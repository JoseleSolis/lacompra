namespace LaCompra.Application.ShoppingList;

public sealed record ShoppingItemDto(int Id, string Description, decimal Quantity, DateTime CreatedAt);

public sealed class CreateShoppingItemRequest
{
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.StringLength(500, MinimumLength = 1)]
    public string Description { get; set; } = string.Empty;

    [System.ComponentModel.DataAnnotations.Range(typeof(decimal), "0.001", "1000000")]
    public decimal Quantity { get; set; } = 1;
}
