using System;
using System.Collections.Generic;

namespace API.Models;

public partial class AdmissionGpatable
{
    public long SubjectId { get; set; }

    public long StudentId { get; set; }

    public string? SubjectCode { get; set; }

    public string? SubjectName { get; set; }
    public string? Grade { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public string? ActiveStatus { get; set; }

    public long? EncodedBy { get; set; }

    public virtual StudentTable Student { get; set; } = null!;
}
