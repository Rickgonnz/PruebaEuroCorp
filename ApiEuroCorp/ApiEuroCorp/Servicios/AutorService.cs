using ApiEuroCorp.Dtos;
using ApiEuroCorp.Entidades;
using ApiEuroCorp.Interfaces;

namespace ApiEuroCorp.Servicios
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepositorio _autorRepositorio;

        public AutorService(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public AutorDTO RegistrarAutor(AutorDTO autorDto)
        {
            // Verificar si el autor ya existe
            var autorExistente = _autorRepositorio.ObtenerAutorPorRut(autorDto.Rut);
            if (autorExistente != null)
            {
                throw new Exception("El autor ya está registrado");
            }

            // Convertir el AutorDTO a una entidad Autor
            var autor = new Autor
            {
                Rut = autorDto.Rut,
                NombreCompleto = autorDto.NombreCompleto,
                FechaNacimiento = autorDto.FechaNacimiento,
                CiudadProcedencia = autorDto.CiudadProcedencia,
                CorreoElectronico = autorDto.CorreoElectronico
            };

            // Registrar el autor en la base de datos
            var autorRegistrado = _autorRepositorio.RegistrarAutor(autor);

            // Retornar el AutorDTO del autor registrado
            return new AutorDTO
            {
                Rut = autorRegistrado.Rut,
                NombreCompleto = autorRegistrado.NombreCompleto,
                FechaNacimiento = autorRegistrado.FechaNacimiento,
                CiudadProcedencia = autorRegistrado.CiudadProcedencia,
                CorreoElectronico = autorRegistrado.CorreoElectronico
            };
        }

        public AutorDTO ObtenerAutorPorRut(string rut)
        {
            // Obtener el autor desde el repositorio
            var autor = _autorRepositorio.ObtenerAutorPorRut(rut);
            if (autor == null)
            {
                throw new Exception("El autor no está registrado");
            }

            // Convertir la entidad Autor a AutorDTO
            var autorDto = new AutorDTO
            {
                Rut = autor.Rut,
                NombreCompleto = autor.NombreCompleto,
                FechaNacimiento = autor.FechaNacimiento,
                CiudadProcedencia = autor.CiudadProcedencia,
                CorreoElectronico = autor.CorreoElectronico
            };

            return autorDto;
        }
        public List<AutorDTO> ObtenerAutores()
        {
            var autores = _autorRepositorio.ObtenerAutores();
            var autoresDto = new List<AutorDTO>();

            foreach (var autor in autores)
            {
                autoresDto.Add(new AutorDTO
                {
                    Rut = autor.Rut,
                    NombreCompleto = autor.NombreCompleto,
                    FechaNacimiento = autor.FechaNacimiento,
                    CiudadProcedencia = autor.CiudadProcedencia,
                    CorreoElectronico = autor.CorreoElectronico
                });
            }

            return autoresDto;
        }
    }
}
