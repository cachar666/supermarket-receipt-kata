namespace supermarket_receipt_kata.Model;

public class Catalogo
{
    private readonly Dictionary<Producto, double> _precios = new();

    public void AgregarProducto(Producto producto, double precio)
    {
        _precios[producto] = precio;
    }

    public double ObtenerPrecio(Producto producto)
    {
        if (_precios.TryGetValue(producto, out var precio))
        {
            return precio;
        }
        throw new ArgumentException($"Producto '{producto.Nombre}' no encontrado en el catálogo");
    }
}