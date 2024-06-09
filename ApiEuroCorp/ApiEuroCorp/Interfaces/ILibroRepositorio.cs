using ApiEuroCorp.Entidades;

namespace ApiEuroCorp.Interfaces
{
    public interface ILibroRepositorio
    {
        Libro RegistrarLibro(Libro libro);
        List<Libro> ObtenerLibrosPorAutor(string autorRut);
    }
}
