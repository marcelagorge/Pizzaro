using Microsoft.EntityFrameworkCore;

public static class PedidoAPI
{

    public static void MapPedidoAPI(this WebApplication app)
    {

        var group = app.MapGroup("/Pedido");

        group.MapGet("/", async (BancoDeDados db) =>
        await db.Pedidos.ToListAsync());

        group.MapPost("/", async (Pedido pedido, BancoDeDados db) =>
        {
            db.Pedidos.Add(pedido);
            await db.SaveChangesAsync();

            return Results.Created($"/pizzas/{pedido.Id}", pedido);
        });

        group.MapPut("/{id}", async (int id, Pedido pedidoAlterado, BancoDeDados db) =>
        {
            var pedido = await db.Pedidos.FindAsync(id);
            if (pedido is null)
            {
                return Results.NotFound();
            }
            pedido.Id = pedidoAlterado.Id;
            pedido.Descricao = pedidoAlterado.Descricao;
            pedido.Preco = pedidoAlterado.Preco;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Pedidos.FindAsync(id) is Pedido pedido)
            {
                db.Pedidos.Remove(pedido);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });

    }
}
