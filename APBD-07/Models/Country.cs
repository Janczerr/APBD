﻿using System;
using System.Collections.Generic;

namespace APBD_07.Models;

public partial class Country
{
    public int IdCountry { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Trip> IdTrips { get; } = new List<Trip>();
}
