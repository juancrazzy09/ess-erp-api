using System;
using System.Collections.Generic;

namespace API.Models;

public partial class CampusTable
{
    public int CampusId { get; set; }

    public string? CampusName { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ActiveStatus { get; set; }
}
