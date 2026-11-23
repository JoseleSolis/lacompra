namespace LaCompra.Application.ShoppingList;

public interface IShoppingListService
{
    Task<IReadOnlyList<ShoppingItemDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<int> AddAsync(CreateShoppingItemRequest request, CancellationToken cancellationToken = default);
    Task RemoveAsync(int id, CancellationToken cancellationToken = default);
}
