using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AS.Api.Dtos
{
    public class InvoiceDto
    {
        public DateTime InvoiceDate { get; set; }
        public decimal Value { get; set; }
        public States State { get; set; }
        public int CustomerId { get; set; }

    }

}
