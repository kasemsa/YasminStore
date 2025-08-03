using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName {  get; set; } = string.Empty;

        public List<UserRole> userRoles { get; set; }
    }
}
