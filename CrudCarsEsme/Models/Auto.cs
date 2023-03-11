using System;
using System.Collections.Generic;

namespace CrudCarsEsme.Models;

public partial class Auto
{
    public int Idauto { get; set; }

    public string? Marca { get; set; }

    public int? MiStatus { get; set; }

    public string? ImgRuta { get; set; }

    public string? Modelo { get; set; }

    public string? Anio { get; set; }
}
