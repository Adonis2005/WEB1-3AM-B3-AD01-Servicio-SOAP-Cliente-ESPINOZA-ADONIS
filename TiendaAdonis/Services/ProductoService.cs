using TiendaAdonis.Data;
using TiendaAdonis.Models;
using CoreWCF;
using System.Collections.Generic;
using System.Linq;

namespace TiendaAdonis.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ProductoService : IProductoService
    {
        private readonly TiendaCocinaDBContext _context;

        public ProductoService(TiendaCocinaDBContext context)
        {
            _context = context;
        }

        public List<Producto> ObtenerProductos()
        {
            return _context.Productos.ToList();
        }

        public Producto? ObtenerProducto(int id)
        {
            return _context.Productos
                .FirstOrDefault(p => p.IdProducto == id);
        }

        public Producto? AgregarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();

            return producto;
        }

        public Producto? ActualizarProducto(Producto producto)
        {
            var productoExistente =
                _context.Productos.Find(producto.IdProducto);

            if (productoExistente == null)
                return null;

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;
            productoExistente.Stock = producto.Stock;
            productoExistente.Estado = producto.Estado;
            productoExistente.IdCategoria = producto.IdCategoria;

            _context.SaveChanges();

            return productoExistente;
        }

        public bool EliminarProducto(int id)
        {
            var producto = _context.Productos.Find(id);

            if (producto == null)
                return false;

            _context.Productos.Remove(producto);
            _context.SaveChanges();

            return true;
        }
    }
}