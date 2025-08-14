using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fortest.Models;

public partial class Test
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Quantity { get; set; }

    public DateTime? LastUpdate { get; set; }

    public string? AuditUser { get; set; }
}
