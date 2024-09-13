using System;
using System.Collections.Generic;
using System.Text;

namespace FulfillData
{
    public class Fulfill
    {
        //Set properties
        public string State { get; set; }
        public string Gender { get; set; }
        public double Mean { get; set; }
        public int N { get; set; }

        //Empty constructor
        public Fulfill()
        {
            State = string.Empty;
            Gender = string.Empty;
            Mean = 0;
            N = 0;
        }

        //Overloaded constructor
        public Fulfill(string state, string gender, double mean, int n)
        {
            State = state;
            Gender = gender;
            Mean = mean;
            N = n;
        }
    }
}
