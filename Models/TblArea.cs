using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fortest.Models;

public partial class TblArea
{
    [Key]
    public int AreaId { get; set; }

    public string? Zone { get; set; }

    public int? AreaNumber { get; set; }

    public int? TId { get; set; }

    public virtual TblTech? TIdNavigation { get; set; }
}
