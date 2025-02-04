﻿using System;
using System.Collections.Generic;

namespace ProjectRegistration.Models;

public partial class Product
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public string? UserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public bool? Deleted { get; set; } = false;

    public DateTime? DeletedDateTime { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();

    public virtual Project? Project { get; set; }

    public virtual User? User { get; set; }
}
