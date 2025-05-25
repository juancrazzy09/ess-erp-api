using System;
using System.Collections.Generic;

namespace API.Models;

public partial class DivisionTable
{
    public int DivId { get; set; }

    public string? DivName { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ActiveStatus { get; set; }
}
