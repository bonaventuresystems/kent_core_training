using System;
using System.Collections.Generic;

namespace CustomerRegistration;

public partial class Customer
{
    public int Cid { get; set; }

    public string? Cname { get; set; }

    public string? Cmail { get; set; }

    public int? Cage { get; set; }

    public bool? Kycstatus { get; set; }
}
