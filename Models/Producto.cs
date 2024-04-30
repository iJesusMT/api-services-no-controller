public class Producto
{
    public long Id { get; set; }
    public required string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string? Descripcion { get; set; }
}