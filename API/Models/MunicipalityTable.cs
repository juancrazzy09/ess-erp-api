using System;
using System.Collections.Generic;

namespace API.Models;

public partial class MunicipalityTable
{
    public long MunicipalityId { get; set; }

    public long? ProvinceId { get; set; }

    public string? MunicipalityName { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ActiveStatus { get; set; }
}
