using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace AutoMapper.Console.Tester.MapObjects
{
    [DataContract]
    public class MapFirstObject
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string PoNumber { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public MapSecondObject SecondObjectEntity { get; set; }

        public MapFirstObject()
        {
        }

        public MapFirstObject(string firstName, string secondName, string poNumber, decimal price, MapSecondObject secondObjectEntity)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.PoNumber = poNumber;
            this.Price = price;
            this.SecondObjectEntity = secondObjectEntity;
            ////SecondObjects = new List<MapSecondObject>();
            ////IntCollection = new List<int>();
        }
    }
}
