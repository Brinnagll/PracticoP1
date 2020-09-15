namespace AdmGorena.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public enum typeplace
    {
        Parque = 10,
        Universidad = 20,
        Casa = 30,
        Restaurante = 40,
        Cine = 50
    }
    public class Gorena
    {
        [Key]
        public int GorenaID { get; set; }

        [StringLength(24, ErrorMessage = "The filed {0} must contain between {2} and {1} characters.", MinimumLength = 2)]
        [DisplayName("Nombre completo")]
        [Required(ErrorMessage = "You must enter your full name {0}")]
        public string FriendOfGorena { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del producto")]
        public typeplace Place { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    }
}