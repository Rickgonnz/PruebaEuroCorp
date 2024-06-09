using ApiEuroCorp.Data;
using ApiEuroCorp.Entidades;
using ApiEuroCorp.Interfaces;

namespace ApiEuroCorp.Repositorios
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly AppDbContext _context;

        public AutorRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public Autor RegistrarAutor (Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
            return autor;
        }

        public Autor ObtenerAutorPorRut(string rut)
        {
            return _context.Autores.FirstOrDefault(a => a.Rut == rut);
        }
        public List<Autor> ObtenerAutores()
        {
            return _context.Autores.ToList();
        }
    }
}
