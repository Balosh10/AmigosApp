﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AmigosApp.Models
{

    public class Amiibos
    {
        public Amiibo[] amiibo { get; set; }
    }

    public class Amiibo
    {
        public string amiiboSeries { get; set; }
        public string character { get; set; }
        public string gameSeries { get; set; }
        public string head { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public Release release { get; set; }
        public string tail { get; set; }
        public string type { get; set; }
    }
}
