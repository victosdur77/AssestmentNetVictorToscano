using System;
using System.Collections.Generic;

namespace AssestmentNET_VictorToscanoDuran.Entities
{
    public partial class Owner
    {
        public Owner()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Drivelicense { get; set; } = null!;

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
