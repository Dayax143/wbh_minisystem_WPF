using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fortest.Models;

public partial class TblTech
{
    [Key]
    public int TId { get; set; }

    public string? TechName { get; set; }

    public string? TechPhone { get; set; }

    public string? Zone { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<TblArea> TblAreas { get; set; } = new List<TblArea>();
}
