﻿using System;
using System.Collections.Generic;


namespace MetricsAgent.Responses
{
    public class AllRamMetricsResponse
    {
        public List<RamMetricDto> Metrics { get; set; }
    }
    public class RamMetricDto
    {

        public DateTimeOffset Time { get; set; }
        public double Available { get; set; }
        public int Id { get; set; }
    }
}
