using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoogleMaps_FinalProjectAspApi.DAL.Entities
{
    public class PlaceDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public double? Rating { get; set; }

        public int? RatingsCount { get; set; }

        public string? Address { get; set; }

        public List<string>? WeekdayDescriptions { get; set; }

        public List<string>? Photos { get; set; }
    }
}
