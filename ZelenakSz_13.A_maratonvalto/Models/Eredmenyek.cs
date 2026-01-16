using System;
using System.Collections.Generic;

namespace ZelenakSz_13.A_maratonvalto.Models;

public partial class Eredmenyek
{
    public Eredmenyek(int futo, int kor, int? ido)
    {
        Futo = futo;
        Kor = kor;
        Ido = ido;
    }

    public int Futo { get; set; }

    public int Kor { get; set; }

    public int? Ido { get; set; }

    public virtual Futok FutoNavigation { get; set; } = null!;
}
