using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Address : ValueObject<Address>
    {
        public string Province { get; private set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string County { get; private set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; private set; }


        public Address() { }
        public Address(string province, string city,
            string county, string street)
        {
            this.Province = province;
            this.City = city;
            this.County = county;
            this.Street = street;
        }
    }
}
