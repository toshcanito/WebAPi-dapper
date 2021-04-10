using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAPI.Models.Interfaces;

namespace webAPI.Models
{
    public class Person : IModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
    }
}