using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.Enums;

namespace YasminStore.Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string CommercialRegistrationNumber { get; set; } = string.Empty;
        public TimeOnly OpenAt { get; set; }
        public TimeOnly ClosedAt {  get; set; }
        public Cities city { get; set; }
        public SaleType saleType { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string? logo { get; set; }
        public string? facebookPage {  get; set; }
        public string? instaAcount {  get; set; }
        public string? whatsapp { get; set; }

        public List<StoreImages> StoreImages { get; set; }
        public List<StoreCategoryStore> storeCategoryStores { get; set; }

    }

}
