using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ReligionTable
{
    public long ReligionId { get; set; }

    public string? ReligionName { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ActiveStatus { get; set; }
}
