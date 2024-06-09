using ApiEuroCorp.Dtos;
using ApiEuroCorp.Entidades;
using ApiEuroCorp.Interfaces;

namespace ApiEuroCorp.Servicios
{
    public class LibroService :ILibroService
    {
        private readonly ILibroRepositorio _libroRepositorio;
        private readonly IAutorRepositorio _autorRepositorio;

        public LibroService(ILibroRepositorio libroRepositorio, IAutorRepositorio autorRepositorio)
        {
            _libroRepositorio = libroRepositorio;
            _autorRepositorio = autorRepositorio;
        }

        public LibroDTO RegistrarLibro(LibroDTO libroDto)
        {
            var autorExistente = _autorRepositorio.ObtenerAutorPorRut(libroDto.AutorRut);
            if (autorExistente == null)
            {
                throw new Exception("El autor no esta registrado");
            }
            var librosDelAutor = _libroRepositorio.ObtenerLibrosPorAutor(libroDto.AutorRut);
            if (librosDelAutor.Count >= 10)
            {
                throw new Exception("No es posible registrar el libro, se alcanzó el máximo permitido");
            }
            var libro = new Libro
            {
                Titulo = libroDto.Titulo,
                Año = libroDto.Año,
                Genero = libroDto.Genero,
                NumeroPaginas = libroDto.NumeroPaginas,
                AutorRut = libroDto.AutorRut
            };

            var libroRegistrado = _libroRepositorio.RegistrarLibro(libro);

            return new LibroDTO
            {
                Titulo = libroRegistrado.Titulo,
                Año = libroRegistrado.Año,
                Genero = libroRegistrado.Genero,
                NumeroPaginas = libroRegistrado.NumeroPaginas,
                AutorRut = libroRegistrado.AutorRut
            };
        }
        public List<LibroDTO> ObtenerLibrosPorAutor(string autorRut)
        {
            var libros = _libroRepositorio.ObtenerLibrosPorAutor(autorRut);

            var librosDTO = new List<LibroDTO>();
            foreach (var libro in libros)
            {
                librosDTO.Add(new LibroDTO
                {
                    Titulo = libro.Titulo,
                    Año = libro.Año,
                    Genero = libro.Genero,
                    NumeroPaginas = libro.NumeroPaginas,
                    AutorRut = libro.AutorRut
                });
            }

            return librosDTO;
        }
    }
}
