using System;

namespace RoutingPractice
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class Test
    {
        public int RowId { get; set; }
        public string Name { get; set; }
    }
}
