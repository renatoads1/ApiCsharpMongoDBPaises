using System;
using System.Collections.Generic;
using System.Text;

namespace consomeapi
{
    class City
    {
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        public City()
        {
        }


        public City(string city, string region, string country, string latitude, string longitude)
        {
            this.city = city;
            this.region = region;
            this.country = country;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public override string ToString()
        {
            return string.Format($"{city} - {region} - {country} - {latitude} - {longitude}");
        }

    }
}
