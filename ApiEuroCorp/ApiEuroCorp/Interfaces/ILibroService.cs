using ApiEuroCorp.Dtos;

namespace ApiEuroCorp.Interfaces
{
    public interface ILibroService
    {
        LibroDTO RegistrarLibro(LibroDTO libroDto);
        List<LibroDTO> ObtenerLibrosPorAutor(string autorRut);
    }
}
