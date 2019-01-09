using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceApi.Domain
{
    public class Location
    {
        public string Country { get; set; }
        public string City { get; set; }
        public Address Address { get; set; }
    }
}
