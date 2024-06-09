using ApiEuroCorp.Entidades;

namespace ApiEuroCorp.Interfaces
{
    public interface IAutorRepositorio
    {
        Autor RegistrarAutor(Autor autor);
        Autor ObtenerAutorPorRut(string rut);
        List<Autor> ObtenerAutores();
    }
}
