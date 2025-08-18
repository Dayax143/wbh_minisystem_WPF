using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fortest.Models;

public partial class TblUser
{
    [Key]
    [Column("user_id")]
    public int user_id { get; set; }

    [Column("fullname")]
    [StringLength(100)]
    public string? fullname { get; set; }

    [Column("userName")]
    [StringLength(20)]
    public string? userName { get; set; }

    [Column("passWord")]
    [StringLength(30)]
    public string? passWord { get; set; }

    [Column("usertype")]
    [StringLength(30)]
    public string? usertype { get; set; }

    [Column("recoveryQuestion")]
    [StringLength(100)]
    public string? recoveryQuestion { get; set; }

    [Column("recoveryAnswer")]
    [StringLength(100)]
    public string? recoveryAnswer { get; set; }

    [Column("userStatus")]
    [StringLength(13)]
    public string? userStatus { get; set; }

    [Column("date")]
    public DateTime? date { get; set; }

}
