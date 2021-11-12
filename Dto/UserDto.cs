using System;
using System.ComponentModel.DataAnnotations;

namespace Population.Dto
{
    public class UserDto
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public bool Gender { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }  
        
        public string HomeNumber { get; set; }
        
        public string Street { get; set; } 
        
        public string District { get; set; } 
    }
}
