using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

public class Pedido
{

    public int Id { get; set; }
    public string? Descricao { get; set; }
    public decimal? Preco { get; set; }

}