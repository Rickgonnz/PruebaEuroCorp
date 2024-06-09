using System.ComponentModel.DataAnnotations;

namespace ApiEuroCorp.Entidades
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Año { get; set; }
        public string Genero { get; set; }
        public int NumeroPaginas { get; set; }
        public string AutorRut { get; set; }

        // Relación con el autor
        public Autor Autor { get; set; }

    }
}
