using Microsoft.EntityFrameworkCore;

public class BancoDeDados : DbContext
{
    //Configuração da conexão
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=pizzaroo;user=root;password=positivo");
    }

    //Mapeamento das tabelas
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }


    //Comandos dotnet
    //dotnet ef migrations add CriarTabelaProduto
    //dotnet ef database update

}
