using System;
using System.Collections.Generic;

namespace HRAPI.Models;

public partial class Emp
{
    public int No { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }
}
