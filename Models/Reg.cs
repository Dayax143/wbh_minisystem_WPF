using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fortest.Models;

public partial class Reg
{
    [Key]
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;
}
