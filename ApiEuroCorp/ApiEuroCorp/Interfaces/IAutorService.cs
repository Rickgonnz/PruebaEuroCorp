using ApiEuroCorp.Dtos;
using ApiEuroCorp.Entidades;

namespace ApiEuroCorp.Interfaces
{
    public interface IAutorService
    {
        AutorDTO RegistrarAutor(AutorDTO autorDto);
        AutorDTO ObtenerAutorPorRut(string rut);
        List<AutorDTO> ObtenerAutores();
    }
}
