using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAPI.Models.Interfaces;

namespace webAPI.Models
{
    public class Vehicle : IModel
    {
        public int id { get; set; }
        public string company { get; set; }
        public string model { get; set; }
        public int personID { get; set; }
    }
}