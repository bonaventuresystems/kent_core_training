using System;
using System.Collections.Generic;

namespace KYCService;

public partial class Customer
{
    public int? Cid { get; set; }

    public string? Cname { get; set; }

    public bool? Kycstatus { get; set; }
}
