using System.ComponentModel.DataAnnotations;

namespace ApiEuroCorp.Entidades
{
    public class Autor
    {
        [Key]
        public string Rut { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string CorreoElectronico { get; set; }

        // Relación con los libros del autor
        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}
