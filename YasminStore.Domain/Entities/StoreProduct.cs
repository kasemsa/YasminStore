using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Domain.Entities
{
    public class StoreProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StoreId {  get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = new Product();

        [ForeignKey(nameof(StoreId))]
        public Store Store { get; set; } = new Store();
    }
}
