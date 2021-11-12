using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.DateTime;

namespace Population.Entity
{
    [Table("users")]
    public record User
    {
        public Guid Id { get; set; }

        [Column("first_name")] [Required] public string FirstName { get; set; }

        [Column("last_name")] [Required] public string LastName { get; set; }

        [Column("gender")] [Required] public bool Gender { get; set; }

        [Column("home_number")] [Required] public string HomeNumber { get; set; }

        [Column("street")] [Required] public string Street { get; set; }

        [Column("district")] [Required] public string District { get; set; }

        [Column("birthday")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        
    }
}
