using LaCompra.Application.ShoppingList;
using LaCompra.Infrastructure.Persistence;
using LaCompra.Infrastructure.ShoppingList;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LaCompra")
    ?? throw new InvalidOperationException("Falta configurar ConnectionStrings:LaCompra.");
builder.Services.AddDbContext<LaCompraDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 4, 0))));
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<LaCompra.Web.Components.App>().AddInteractiveServerRenderMode();
app.Run();
