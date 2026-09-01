using TiendaAdonis.Data;
using TiendaAdonis.Models;
using CoreWCF;
using System.Collections.Generic;
using System.Linq;

namespace TiendaAdonis.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CategoriaService : ICategoriaService
    {
        private readonly TiendaCocinaDBContext _context;

        public CategoriaService(TiendaCocinaDBContext context)
        {
            _context = context;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return _context.Categorias.ToList();
        }

        public Categoria? ObtenerCategoria(int id)
        {
            return _context.Categorias
                .FirstOrDefault(c => c.IdCategoria == id);
        }

        public Categoria? AgregarCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public Categoria? ActualizarCategoria(Categoria categoria)
        {
            var categoriaExistente =
                _context.Categorias.Find(categoria.IdCategoria);

            if (categoriaExistente == null)
                return null;

            categoriaExistente.Nombre = categoria.Nombre;
            categoriaExistente.Descripcion = categoria.Descripcion;
            categoriaExistente.Estado = categoria.Estado;

            _context.SaveChanges();

            return categoriaExistente;
        }

        public bool EliminarCategoria(int id)
        {
            var categoria = _context.Categorias.Find(id);

            if (categoria == null)
                return false;

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return true;
        }
    }
}