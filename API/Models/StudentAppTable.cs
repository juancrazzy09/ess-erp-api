using System;
using System.Collections.Generic;

namespace API.Models;

public partial class StudentAppTable
{
    public long AppId { get; set; }

    public long? StudentId { get; set; }

    public string? AppNumber { get; set; }

    public string? ActiveStatus { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual StudentTable? Student { get; set; }
}
