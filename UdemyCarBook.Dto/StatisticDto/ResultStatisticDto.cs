﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.StatisticDto
{
    public class ResultStatisticDto
    {
        public int CarCount { get; set; }
        public int locationCount { get; set; }
        public int authorCount { get; set; }
        public int blogCount { get; set; }
        public int brandCount { get; set; }
        public decimal avPriceForDaily { get; set; }
        public decimal avPriceForWeekly { get; set; }
        public decimal avPriceForMonthly { get; set; }
    }
}
