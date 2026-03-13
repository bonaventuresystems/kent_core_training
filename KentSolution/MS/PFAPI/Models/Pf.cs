using System;
using System.Collections.Generic;

namespace PFAPI.Models;

public partial class Pf
{
    public int Pfacno { get; set; }

    public int Cno { get; set; }
}

public partial class Emp
{
    public int No { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }
}


