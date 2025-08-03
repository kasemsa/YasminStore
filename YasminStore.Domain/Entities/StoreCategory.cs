using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Domain.Entities
{
    public class StoreCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<StoreCategoryStore> storeCategoryStores { get; set; }
    }
}
