# LaCompra

Aplicación web doméstica para gestionar una lista de la compra compartida en una red local.

## Stack

- .NET 10
- Blazor Web App con Interactive Server
- Entity Framework Core 10
- MySQL 8.4 mediante Pomelo

## Estructura

- `LaCompra.Core`: entidades y modelo de dominio.
- `LaCompra.Application`: contratos y casos de uso.
- `LaCompra.Infrastructure`: persistencia EF Core y servicios.
- `LaCompra.Web`: interfaz Blazor y composición de dependencias.

## Requisitos

- .NET 10 SDK
- Docker Desktop (opcional, para ejecutar MySQL localmente)
- MySQL 8.4 si no se utiliza Docker

## Arranque local

1. Inicia MySQL:

   ```bash
   docker compose up -d
   ```

2. Cambia las contraseñas de ejemplo en `docker-compose.yml` y en `src/LaCompra.Web/appsettings.json`. No uses esos valores en un entorno real.

3. Desde la raíz, instala la herramienta EF si aún no está instalada:

   ```bash
   dotnet tool install --global dotnet-ef --version 10.0.0
   ```

4. Genera y aplica la migración inicial:

   ```bash
   dotnet ef migrations add InitialCreate --project src/LaCompra.Infrastructure --startup-project src/LaCompra.Web --output-dir Persistence/Migrations
   dotnet ef database update --project src/LaCompra.Infrastructure --startup-project src/LaCompra.Web
   ```

5. Ejecuta la aplicación:

   ```bash
   dotnet run --project src/LaCompra.Web
   ```

Para permitir el acceso desde otros dispositivos de la red local, configura Kestrel para escuchar en la interfaz de red (por ejemplo, `ASPNETCORE_URLS=http://0.0.0.0:5080`) y permite ese puerto en el firewall del ordenador servidor. Los dispositivos accederán usando la IP local de ese ordenador.

## Estado actual

La primera base contiene la solución, el modelo inicial de usuarios y artículos, persistencia de lista y una pantalla para añadir, consultar y quitar artículos. Todavía no están implementados el inicio de sesión, las imágenes, el registro de compras ni el historial.
