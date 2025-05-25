using System;
using System.Collections.Generic;

namespace API.Models;

public partial class FathersTable
{
    public long FatherId { get; set; }

    public long StudentId { get; set; }

    public string? Fname { get; set; }

    public string? Mname { get; set; }

    public string? Lname { get; set; }

    public long? ReligionId { get; set; }

    public long? NationalityId { get; set; }

    public long? EducationalLevelId { get; set; }

    public string? Course { get; set; }

    public string? MobilePhoneNo { get; set; }

    public string? Occupation { get; set; }

    public string? Email { get; set; }

    public string? EmployersName { get; set; }

    public string? EmployersAddress { get; set; }

    public string? WorkPhoneNo { get; set; }

    public string? Monthlyincome { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? PlaceOfBirth { get; set; }

    public string? LifeStatus { get; set; }

    public string? IsAlumnae { get; set; }

    public string? SchoolGraduated { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public string? ActiveStatus { get; set; }

    public virtual StudentTable Student { get; set; } = null!;
}
