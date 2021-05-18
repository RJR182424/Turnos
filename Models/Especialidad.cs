using System.ComponentModel.DataAnnotations;

namespace Turnos.Models{
    public class Especialidad{

        [Key]
        public int IdEspecialidad{get;set;}
        /*Primary key de la tabla*/
        public string Descripcion{get; set;}
    }
}