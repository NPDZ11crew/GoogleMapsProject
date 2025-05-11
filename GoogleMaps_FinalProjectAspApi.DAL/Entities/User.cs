using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps_FinalProjectAspApi.DAL.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? TelegramId { get; set; }
        public string? LastCity { get; set; }
        public double? ActualLatitude { get; set; }
        public double? ActualLongitude { get; set; }
    }   
}
