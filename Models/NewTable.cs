using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fortest.Models;

public partial class NewTable
{
    [Key]
    public int LoraId { get; set; }

    public string? CorSupply { get; set; }

    public string? Status { get; set; }

    public string? Refference { get; set; }

    public DateTime? TakenDate { get; set; }

    public string? ReceiptRv { get; set; }

    public string? LoraSerial { get; set; }

    public DateTime? Date { get; set; }

    public string? Plate { get; set; }

    public string? Note { get; set; }
}
