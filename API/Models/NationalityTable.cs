using System;
using System.Collections.Generic;

namespace API.Models;

public partial class NationalityTable
{
    public int NationalityId { get; set; }

    public string? NationalityName { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ActiveStatus { get; set; }
}
