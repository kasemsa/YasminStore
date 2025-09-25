using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.ApplicationContract.DTOs.Role
{
    public class UpdateRoleDto
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string RoleName { get; set; } = string.Empty;
    }
}
