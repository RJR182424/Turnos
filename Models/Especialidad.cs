using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad
    {

        [Key] /*esto es un Data Annotations*/
        public int IdEspecialidad { get; set; }
        /*Primary key de la tabla*/
        [StringLength(200, ErrorMessage ="El campo descripción debe tener como máximo 200 caracteres")]
        [Required (ErrorMessage = "Debe ingresar una descripción")]
        [Display (Name = "Descripción", Prompt = "Ingrese una descripción")]
        public string Descripcion { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }

    }
}