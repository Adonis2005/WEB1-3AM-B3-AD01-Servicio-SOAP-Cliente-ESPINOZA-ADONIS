using TiendaAdonis.Models;
using CoreWCF;
using System.Collections.Generic;

namespace TiendaAdonis.Services
{
    [ServiceContract]
    public interface ICategoriaService
    {
        [OperationContract]
        List<Categoria> ObtenerCategorias();

        [OperationContract]
        Categoria? ObtenerCategoria(int id);

        [OperationContract]
        Categoria? AgregarCategoria(Categoria categoria);

        [OperationContract]
        Categoria? ActualizarCategoria(Categoria categoria);

        [OperationContract]
        bool EliminarCategoria(int id);
    }
}