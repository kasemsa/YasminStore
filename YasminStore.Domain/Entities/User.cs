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
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public List<UserRole> userRoles { get; set; } = new();
    }
}
