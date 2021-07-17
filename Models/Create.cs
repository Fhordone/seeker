using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seeker.Models{
    [Table("t_loan")]
    public class Create {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}
        [Required(ErrorMessage = "Please enter name")]
        [Column("name")]
        public string name {get;set;}

         [Required(ErrorMessage = "Please enter date")]
        [Column("fecha")]
        [DataType(DataType.Date)]
        public DateTime loan_date {get; set;}

        [Required(ErrorMessage = "Please enter book")]
        [Column("libro")]
        public double original_amount {get; set;}

        [Required(ErrorMessage = "Please enter page")]
        [Column("pagina")]
        public double rate {get; set;}

        [NotMapped]
        public string Mensaje { get; set; }

        [NotMapped]
        public Double Operacion { get; set; }
    }
}