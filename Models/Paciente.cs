using System.ComponentModel.DataAnnotations;

namespace Turnos.Models{
    public class Paciente{
        [Key]
        public int IdPaciente{get; set;}
        [Required(ErrorMessage ="Debe ingresar un nombre")]
        public string Nombre{get; set;}
        [Required(ErrorMessage ="Debe ingresar un apellido")]
        public string Apellidos{get; set;}
        [Required(ErrorMessage ="Debe ingresar un dirección")]
        [Display (Name = "Dirección")]
        public string Direccion{get; set;}
        [Required(ErrorMessage ="Debe ingresar un teléfono")]
        [Display (Name = "Teléfono")]
        public string Telefono{get; set;}
        [Required(ErrorMessage ="Debe ingresar un email")]
        [EmailAddress (ErrorMessage ="No es una direccion de email valida")]
        public string Email{get; set;}
    }
}