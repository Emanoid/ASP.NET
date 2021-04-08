using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    /// <summary>
    /// Represents one specific person
    /// </summary>
    public class Person
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = "";
        public string Lastname { get; set; } = "";

    }
}