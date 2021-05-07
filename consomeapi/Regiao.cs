using System;
using System.Collections.Generic;
using System.Text;

namespace consomeapi
{
    class Regiao
    {

        public string Region { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return string.Format($"{Region} - {Country}");
        }
    }
}
