using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ProvincesTable
{
    public long ProvinceId { get; set; }

    public string? ProvinceName { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ActiveStatus { get; set; }
}
