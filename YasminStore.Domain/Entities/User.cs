using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; } 

        public List<UserRole> userRoles { get; set; }

    }
}
