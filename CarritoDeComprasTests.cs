using FluentAssertions;
using supermarket_receipt_kata.Model;

namespace supermarket_receipt_kata;

public class CarritoDeComprasTests
{
    [Fact]
    public void Si_CarritoVacio_Debe_TotalReciboSerCero()
    {
        // Arrange
        var catalogo = new Catalogo();
        var carrito = new CarritoDeCompras();
        
        // Act
        var total = carrito.CalcularTotal(catalogo);
        
        // Assert
        total.Should().Be(0.0m);  // ← Nota la 'm'
    }
    
    [Fact]
    public void Si_AgregoUnProductoPorUnidad_Debe_CalcularPrecioCorrecto()
    {
        // Arrange
        var catalogo = new Catalogo();
        var manzanas = new Producto("Manzanas", TipoProducto.PorUnidad);
        catalogo.AgregarProducto(manzanas, 2.50m);  // ← 'm'
        
        var carrito = new CarritoDeCompras();
        
        // Act
        carrito.AgregarItem(manzanas, 1m);  // ← 'm'
        var total = carrito.CalcularTotal(catalogo);
        
        // Assert
        total.Should().Be(2.50m);  // ← 'm'
    }
    
    [Fact]
    public void Si_AgregoVariasUnidadesMismoProducto_Debe_MultiplicarPrecio()
    {
        // Arrange
        var catalogo = new Catalogo();
        var leche = new Producto("Leche", TipoProducto.PorUnidad);
        catalogo.AgregarProducto(leche, 3.20m);  // ← 'm'
        
        var carrito = new CarritoDeCompras();
        
        // Act
        carrito.AgregarItem(leche, 3m);  // ← 'm'
        var total = carrito.CalcularTotal(catalogo);
        
        // Assert
        total.Should().Be(9.60m);  // ← 'm'
    }
}