using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChristopherDemos.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public String Name { get; set; }
    }
}