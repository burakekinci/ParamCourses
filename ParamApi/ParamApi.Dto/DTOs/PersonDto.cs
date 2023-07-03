using ParamApi.Base;
using System.ComponentModel.DataAnnotations;

namespace ParamApi.Dto.DTOs
{
    public class PersonDto
    {
        [Required]
        [MaxLength(25)]
        [Display(Name = "StaffId")]
        public string StaffId { get; set; }


        [Required]
        [MaxLength(50)]
        [Display(Name = "FirstName")]

        public string FirstName { get; set; }


        [Required]
        [MaxLength(50)]
        [Display(Name = "LastName")]

        public string LastName { get; set; }


        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }


        [MaxLength(500)]
        public string Description { get; set; }


        [Phone]
        [MaxLength(25)]
        public string Phone { get; set; }


        [Required]
        [DateOfBirth]
        [DataType(DataType.Date)]
        [Display(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }


        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }
}
