using System;
using System.Collections.Generic;

namespace ZelenakSz_13.A_maratonvalto.Models;

public partial class Futok
{
    public int Fid { get; set; }

    public string? Fnev { get; set; }

    public int? Szulev { get; set; }

    public int? Szulho { get; set; }

    public int? Csapat { get; set; }

    public bool? Ffi { get; set; }

    public virtual ICollection<Eredmenyek> Eredmenyeks { get; set; } = new List<Eredmenyek>();
}
