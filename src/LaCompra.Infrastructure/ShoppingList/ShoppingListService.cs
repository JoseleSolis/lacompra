using LaCompra.Application.ShoppingList;
using LaCompra.Core.Entities;
using LaCompra.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LaCompra.Infrastructure.ShoppingList;

public sealed class ShoppingListService(LaCompraDbContext dbContext) : IShoppingListService
{
    public async Task<IReadOnlyList<ShoppingItemDto>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await dbContext.ShoppingItems.AsNoTracking().OrderBy(x => x.Description)
            .Select(x => new ShoppingItemDto(x.Id, x.Description, x.Quantity, x.CreatedAt))
            .ToListAsync(cancellationToken);

    public async Task<int> AddAsync(CreateShoppingItemRequest request, CancellationToken cancellationToken = default)
    {
        var description = request.Description.Trim();
        if (description.Length == 0) throw new ArgumentException("La descripción no puede estar vacía.", nameof(request));
        if (request.Quantity <= 0) throw new ArgumentOutOfRangeException(nameof(request), "La cantidad debe ser mayor que cero.");
        var item = new ShoppingItem { Description = description, Quantity = request.Quantity };
        dbContext.ShoppingItems.Add(item);
        await dbContext.SaveChangesAsync(cancellationToken);
        return item.Id;
    }

    public async Task RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        var item = await dbContext.ShoppingItems.FindAsync([id], cancellationToken);
        if (item is null) return;
        dbContext.ShoppingItems.Remove(item);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
