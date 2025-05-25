using System;
using System.Collections.Generic;

namespace API.Models;

public partial class BarangayTable
{
    public long BrgyId { get; set; }

    public long? MunicipalityId { get; set; }

    public string? BrgyName { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ActiveStatus { get; set; }
}
