using ApiEuroCorp.Data;
using ApiEuroCorp.Entidades;
using ApiEuroCorp.Interfaces;

namespace ApiEuroCorp.Repositorios
{
    public class LibroRepositorio :ILibroRepositorio
    {
        private readonly AppDbContext _context;

        public LibroRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public Libro RegistrarLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
            return libro;
        }
        public List<Libro> ObtenerLibrosPorAutor(string autorRut)
        {
            return _context.Libros.Where(l => l.AutorRut == autorRut).ToList();
        }
    }
}
