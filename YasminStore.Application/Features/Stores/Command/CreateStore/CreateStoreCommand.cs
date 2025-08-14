using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Application.Features.Stores.Commands.CreateStore.Dtos;
using YasminStore.ApplicationContract.DTOs;
using YasminStore.Domain.Entities;
using YasminStore.Domain.Enums;

namespace YasminStore.Application.Features.Stores.Command.CreateStore
{



    public class CreateStoreCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string CommercialRegistrationNumber { get; set; } = string.Empty;
        public TimeOnly OpenAt { get; set; }
        public TimeOnly ClosedAt { get; set; }
        public Cities City { get; set; }
        public SaleType SaleType { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Logo { get; set; }
        public string? FacebookPage { get; set; }
        public string? InstaAccount { get; set; }
        public string? Whatsapp { get; set; }
        public string? Telegram { get; set; }
        public List<int> CategoryIds { get; set; } = new();
    }

}
