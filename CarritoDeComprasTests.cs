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
    
    [Fact]
    public void Si_AgregoVariosProductosDiferentes_Debe_SumarTodosLosPrecios()
    {
        // Arrange
        var catalogo = new Catalogo();
        var manzanas = new Producto("Manzanas", TipoProducto.PorUnidad);
        var pan = new Producto("Pan", TipoProducto.PorUnidad);
        var leche = new Producto("Leche", TipoProducto.PorUnidad);
        
        catalogo.AgregarProducto(manzanas, 2.50m);
        catalogo.AgregarProducto(pan, 1.80m);
        catalogo.AgregarProducto(leche, 3.20m);
        
        var carrito = new CarritoDeCompras();
        
        // Act
        carrito.AgregarItem(manzanas, 2m);  // 2.50 * 2 = 5.00
        carrito.AgregarItem(pan, 1m);       // 1.80 * 1 = 1.80
        carrito.AgregarItem(leche, 1m);     // 3.20 * 1 = 3.20
        var total = carrito.CalcularTotal(catalogo);
        
        // Assert
        total.Should().Be(10.00m);  // 5.00 + 1.80 + 3.20 = 10.00
    }
    
    [Fact]
    public void Si_AgregoProductoPorPeso_Debe_CalcularSegunKilos()
    {
        // Arrange
        var catalogo = new Catalogo();
        var queso = new Producto("Queso", TipoProducto.PorPeso);
        catalogo.AgregarProducto(queso, 12.50m);  // $12.50 por kilo
        
        var carrito = new CarritoDeCompras();
        
        // Act
        carrito.AgregarItem(queso, 0.5m);  // 500 gramos = 0.5 kilos
        var total = carrito.CalcularTotal(catalogo);
        
        // Assert
        total.Should().Be(6.25m);  // 12.50 * 0.5 = 6.25
    }
    
    [Fact]
    public void Si_AgregoProductoPorPesoConDecimales_Debe_CalcularCorrectamente()
    {
        // Arrange
        var catalogo = new Catalogo();
        var jamon = new Producto("Jamón", TipoProducto.PorPeso);
        catalogo.AgregarProducto(jamon, 20.00m);  // $20.00 por kilo
        
        var carrito = new CarritoDeCompras();
        
        // Act
        carrito.AgregarItem(jamon, 0.333m);  // 333 gramos
        var total = carrito.CalcularTotal(catalogo);
        
        // Assert
        total.Should().Be(6.66m);  // 20.00 * 0.333 = 6.66
    }
    
    // VALIDACIONES
    
    [Fact]
    public void Si_CantidadEsNegativa_Debe_LanzarExcepcion()
    {
        // Arrange
        var carrito = new CarritoDeCompras();
        var producto = new Producto("Manzanas", TipoProducto.PorUnidad);
        
        // Act
        Action act = () => carrito.AgregarItem(producto, -1m);
        
        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*cantidad*mayor*cero*");
    }
    
    [Fact]
    public void Si_CantidadEsCero_Debe_LanzarExcepcion()
    {
        // Arrange
        var carrito = new CarritoDeCompras();
        var producto = new Producto("Pan", TipoProducto.PorUnidad);
        
        // Act
        Action act = () => carrito.AgregarItem(producto, 0m);
        
        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*cantidad*mayor*cero*");
    }
}