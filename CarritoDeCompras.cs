using supermarket_receipt_kata.Model;

namespace supermarket_receipt_kata;

public class CarritoDeCompras
{
    private readonly List<ItemCarrito> _items = new();

    public void AgregarItem(Producto producto, double cantidad)
    {
        _items.Add(new ItemCarrito(producto, cantidad));
    }

    public double CalcularTotal(Catalogo catalogo)
    {
        double total = 0.0;
        
        foreach (var item in _items)
        {
            var precioUnitario = catalogo.ObtenerPrecio(item.Producto);
            total += precioUnitario * item.Cantidad;
        }
        
        return total;
    }
}

public class ItemCarrito
{
    public Producto Producto { get; }
    public double Cantidad { get; }

    public ItemCarrito(Producto producto, double cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
    }
}