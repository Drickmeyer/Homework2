using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationHandout
{
    public class Address
    {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

        public Address()
        {
            StreetNumber = 0;
            StreetName = string.Empty;
            State = string.Empty;
            City = string.Empty;
            ZipCode = 0;
        }

        public Address(int streetNumber, string streetName, string state, string city, int zipCode)
        {
            StreetNumber = streetNumber;
            StreetName = streetName;
            State = state;
            City = city;
            ZipCode = zipCode;
        }

    }
}
