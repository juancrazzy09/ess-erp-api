using System;
using System.Collections.Generic;

namespace API.Models;

public partial class StrandTable
{
    public int StrandId { get; set; }

    public int? LevelId { get; set; }

    public string? StrandName { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ActiveStatus { get; set; }
}
