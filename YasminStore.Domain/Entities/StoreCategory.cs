using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Domain.Entities
{
    public class StoreCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int CategoryId {  get; set; }
        public int StoreId {  get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = new Category();

        [ForeignKey(nameof(StoreId))]
        public Store Store { get; set; } = new Store();
    }
}
