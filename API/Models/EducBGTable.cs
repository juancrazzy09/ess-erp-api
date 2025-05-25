using System;
using System.Collections.Generic;

namespace API.Models;

public partial class EducBgtable
{
    public int EducBgId { get; set; }

    public string? EducBgName { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ActiveStatus { get; set; }
}
