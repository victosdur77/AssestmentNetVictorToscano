using System;
using System.Collections.Generic;

namespace AssestmentNET_VictorToscanoDuran.Entities
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Claims = new HashSet<Claim>();
        }

        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Vin { get; set; } = null!;
        public string Color { get; set; } = null!;
        public DateTime Year { get; set; }
        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; } = null!;
        public virtual ICollection<Claim> Claims { get; set; }
    }
}
