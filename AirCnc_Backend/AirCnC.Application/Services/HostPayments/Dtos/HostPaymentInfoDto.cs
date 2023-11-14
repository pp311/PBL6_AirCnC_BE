using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AirCnC.Application.Services.HostPayments.Dtos
{
    public class HostPaymentInfoDto
    {
        public int HostId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountHolder { get; set; } = string.Empty;
    }
}
