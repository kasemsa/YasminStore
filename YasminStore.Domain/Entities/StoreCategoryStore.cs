using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Domain.Entities
{
    public class StoreCategoryStore
    {
        public int Id {  get; set; }
        public int StoreCategoryId {  get; set; }
        public int StoreId {  get; set; }

        [ForeignKey(nameof(StoreCategoryId))]
        public StoreCategory StoreCategory { get; set; }

        [ForeignKey(nameof(StoreId))]
        public Store Store { get; set; }
    }
}
