using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResidentApi.Models
{
    public class Resident
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public string Building { get; set; }
    }
}
