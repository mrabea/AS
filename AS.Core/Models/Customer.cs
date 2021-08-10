using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Customer
{
    public int CustomerId { get; set; }
    [Required]

    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public List<Invoice> Invoices { get; set; }


}
