using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fortest.Models;

public partial class NewTable
{
    [Key]
    [Column("lora_id")]
    public int lora_id { get; set; }

    //[Column("cor_supply")]
    [StringLength(20)]
    public string? cor_supply { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string? status { get; set; }

    [Column("refference")]
    [StringLength(40)]
    public string? refference { get; set; }

    [Column("taken_date")]
    public DateTime? taken_date { get; set; }

    //[Column("receipt_rv")]
    [StringLength(20)]
    public string? receipt_rv { get; set; }

    [Column("lora_serial")]
    [StringLength(20)]
    public string? lora_serial { get; set; }

    [Column("date")]
    public DateTime? date { get; set; }

    [Column("plate")]
    [StringLength(10)]
    public string? plate { get; set; }

    [Column("note")]
    [StringLength(150)]
    public string? note { get; set; }

    [Column("users")]
    [StringLength(50)]
    public string? users { get; set; }

    [Column("assigned_to")]
    [StringLength(50)]
    public string? assigned_to { get; set; }
}
