using Humanizer;
using System.Collections.Generic;
using System.Security;

namespace Insurance.Models;

public partial class Payment
{

    public string? cus_Name { get; set; }
    public int? ExpirationDate {  get; set; }
    public int? PaymentId { get; set; }
    public int? cardNumber { get; set; }
    public string? SecurityCode{ get; set; }
}
