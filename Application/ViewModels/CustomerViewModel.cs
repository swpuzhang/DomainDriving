using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is requird")]
        [DisplayName("Name")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The BirthDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

    }
}
