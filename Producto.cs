namespace supermarket_receipt_kata.Model;

public enum TipoProducto
{
    PorUnidad,
    PorPeso
}

public class Producto
{
    public string Nombre { get; }
    public TipoProducto Tipo { get; }

    public Producto(string nombre, TipoProducto tipo)
    {
        Nombre = nombre;
        Tipo = tipo;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Producto otroProducto)
            return false;

        return Nombre == otroProducto.Nombre 
               && Tipo == otroProducto.Tipo;
    }

    public override int GetHashCode()
    {
        return (Nombre, Tipo).GetHashCode();
    }
}