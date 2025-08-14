using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fortest.Models;

public partial class TblRfm
{
    [Key]
    public int RfmId { get; set; }

    public string? RfmMac { get; set; }

    public int? MreaderId { get; set; }

    public string? Status { get; set; }

    public DateTime? Date { get; set; }

    public virtual TblMreader? Mreader { get; set; }

    public virtual ICollection<TblHistory> TblHistories { get; set; } = new List<TblHistory>();
}
