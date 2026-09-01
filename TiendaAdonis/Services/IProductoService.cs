using TiendaAdonis.Models;
using CoreWCF;
using System.Collections.Generic;

namespace TiendaAdonis.Services
{
    [ServiceContract]
    public interface IProductoService
    {
        [OperationContract]
        List<Producto> ObtenerProductos();

        [OperationContract]
        Producto? ObtenerProducto(int id);

        [OperationContract]
        Producto? AgregarProducto(Producto producto);

        [OperationContract]
        Producto? ActualizarProducto(Producto producto);

        [OperationContract]
        bool EliminarProducto(int id);
    }
}