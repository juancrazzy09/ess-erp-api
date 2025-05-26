using System;
using System.Collections.Generic;

namespace API.Models;

public partial class DocumentFileTable
{
    public long FileId { get; set; }

    public long UserId { get; set; }

    public long UploadedById { get; set; }

    public string? DocumentType { get; set; }

    public string? OriginalFileName { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public string? Remarks { get; set; }

    public string? ActiveStatus { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
