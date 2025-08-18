using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fortest.Models;

public partial class TblPlate
{
    [Key]
    [Column("plate_id")]
    public int plate_id { get; set; }

    [Column("cor_supply")]
    [StringLength(20)]
    public string? cor_supply { get; set; }

    [Column("status")]
    [StringLength(10)]
    public string? status { get; set; }

    [Column("refference")]
    [StringLength(30)]
    public string? refference { get; set; }

    [Column("date")]
    public DateTime? date { get; set; }

    [Column("quantity")]
    public int? quantity { get; set; }

    [Column("note")]
    [StringLength(100)]
    public string? note { get; set; }

    [Column("ref_user")]
    [StringLength(100)]
    public string? ref_user { get; set; }

    [Column("if_deleted ")]
    [StringLength(10)]
    public string? if_deleted { get; set; }
}
