using System;
using System.Collections.Generic;

namespace API.Models;

public partial class LevelTable
{
    public int LevelId { get; set; }

    public int? DivId { get; set; }

    public string? LevelName { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ActiveStatus { get; set; }
}
