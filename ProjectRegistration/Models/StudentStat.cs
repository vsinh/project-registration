﻿using System;
using System.Collections.Generic;

namespace ProjectRegistration.Models;

public partial class StudentStat
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? Semester { get; set; }

    public string? Syear { get; set; }

    public double? AvgGrade { get; set; }

    public int? TotalProjects { get; set; }

    public int? FinishedProjects { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public bool? Deleted { get; set; }

    public DateTime? DeletedDateTime { get; set; }

    public virtual User? Student { get; set; }
}
