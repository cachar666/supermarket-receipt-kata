namespace supermarket_receipt_kata.Model;

public class Catalogo
{
    private readonly Dictionary<Producto, decimal> _precios = new();

    public void AgregarProducto(Producto producto, decimal precio)
    {
        _precios[producto] = precio;
    }

    public decimal ObtenerPrecio(Producto producto)
    {
        if (_precios.TryGetValue(producto, out var precio))
        {
            return precio;
        }
        throw new ArgumentException($"Producto '{producto.Nombre}' no encontrado en el catálogo");
    }
}