using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Domain.Entities;

namespace YasminStore.ApplicationContract.DTOs.Role
{
    public class RoleResponseDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
