using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fortest.Models;

public partial class TblMreader
{
    [Key]
    public int MId { get; set; }

    public string? MReaderName { get; set; }

    public string? ReadingArea { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<TblHistory> TblHistories { get; set; } = new List<TblHistory>();

    public virtual ICollection<TblRfm> TblRfms { get; set; } = new List<TblRfm>();
}
