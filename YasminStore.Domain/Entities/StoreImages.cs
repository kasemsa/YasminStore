using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasminStore.Domain.Entities
{
    public  class StoreImages
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public int StoreId {  get; set; }
        public string Image {  get; set; }

        [ForeignKey(nameof(StoreId))]
        public Store Store { get; set; }
    }
}
