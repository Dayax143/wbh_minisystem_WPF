using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fortest.Models;

public partial class TblHistory
{
    [Key]
    public int HistoryId { get; set; }

    public int? MreaderId { get; set; }

    public string? ReaderName { get; set; }

    public int? RfmId { get; set; }

    public string? RfmMac { get; set; }

    public string? Status { get; set; }

    public DateTime? Date { get; set; }

    public string? Note { get; set; }

    public virtual TblMreader? Mreader { get; set; }

    public virtual TblRfm? Rfm { get; set; }
}
