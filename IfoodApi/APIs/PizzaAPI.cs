using Microsoft.EntityFrameworkCore;

public static class PizzaAPI
{

    public static void MapPizzaAPI(this WebApplication app)
    {

        var group = app.MapGroup("/Pizzas");

        group.MapGet("/", async (BancoDeDados db) =>
        await db.Pizzas.ToListAsync());

        group.MapPost("/", async (Pizza pizza, BancoDeDados db) =>
        {
            db.Pizzas.Add(pizza);
            await db.SaveChangesAsync();

            return Results.Created($"/pizzas/{pizza.Id}", pizza);
        });

        group.MapPut("/{id}", async (int id, Pizza pizzaAlterada, BancoDeDados db) =>
        {
            var pizza = await db.Pizzas.FindAsync(id);
            if (pizza is null)
            {
                return Results.NotFound();
            }
            pizza.Nome = pizzaAlterada.Nome;
            pizza.Descricao = pizzaAlterada.Descricao;
            pizza.Preco = pizzaAlterada.Preco;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, BancoDeDados db) =>
        {
            if (await db.Pizzas.FindAsync(id) is Pizza pizza)
            {
                db.Pizzas.Remove(pizza);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });




    }
}