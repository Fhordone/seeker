using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seeker.Models{
    [Table("t_users")]
    public class Create {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}
        
        [Required(ErrorMessage = "Please enter first name")]
        [Column("first_name")]
        public string first_name {get;set;}

        [Required(ErrorMessage = "Please enter last name")]
        [Column("last_name")]
        public string last_name {get;set;}

         [Required(ErrorMessage = "Please enter date")]
        [Column("fecha")]
        [DataType(DataType.Date)]
        public DateTime fecha {get; set;}

        [Required(ErrorMessage = "Please enter book")]
        [Column("libro")]
        public double libro {get; set;}

        [Required(ErrorMessage = "Please enter page")]
        [Column("pagina")]
        public double pagina {get; set;}

        [NotMapped]
        public string Mensaje { get; set; }

        [NotMapped]
        public Double Operacion { get; set; }
    }
}