﻿using System;
using System.Collections.Generic;

namespace API.Models;

public partial class UsersTable
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string? Fname { get; set; }

    public string? Mname { get; set; }

    public string? Lname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public string? ActiveStatus { get; set; }

    public string? UserRole { get; set; }

    public string? SpecialRole { get; set; }

    public virtual StudentTable User { get; set; } = null!;
}
