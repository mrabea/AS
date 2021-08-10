using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Invoice
{
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public Customer customer { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal Value { get; set; }
    public States State { get; set; }
}
public enum States
{
    [Description("DRAFT")]
    DRAFT,
    [Description("UNPAID")]
    UNPAID,
    [Description("SCHEDULED")]
    SCHEDULED,
    [Description("PARTIALLY_PAID")]
    PARTIALLY_PAID,
    [Description("PAID")]
    PAID,
    [Description("PARTIALLY_REFUNDED")]
    PARTIALLY_REFUNDED,
    [Description("REFUNDED")]

    REFUNDED,
    [Description("CANCELED")]
    CANCELED,
    [Description("FAILED")]
    FAILED

}
