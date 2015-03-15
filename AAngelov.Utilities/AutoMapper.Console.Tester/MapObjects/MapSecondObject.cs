using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Console.Tester.MapObjects
{
    [DataContract]
    public class MapSecondObject
    {
        [DataMember]
        public string FirstNameS { get; set; }
        [DataMember]
        public string SecondNameS { get; set; }
        [DataMember]
        public string PoNumberS { get; set; }
        [DataMember]
        public decimal PriceS { get; set; }
        public MapThirdObject ThirdObject1 { get; set; }
        public MapThirdObject ThirdObject2 { get; set; }
        public MapThirdObject ThirdObject3 { get; set; }
        public MapThirdObject ThirdObject4 { get; set; }
        public MapThirdObject ThirdObject5 { get; set; }
        public MapThirdObject ThirdObject6 { get; set; }

        public MapSecondObject(string firstNameS, string secondNameS, string poNumberS, decimal priceS)
        {
            this.FirstNameS = firstNameS;
            this.SecondNameS = secondNameS;
            this.PoNumberS = poNumberS;
            this.PriceS = priceS;
            ThirdObject1 = new MapThirdObject();
            ThirdObject2 = new MapThirdObject();
            ThirdObject3 = new MapThirdObject();
            ThirdObject4 = new MapThirdObject();
            ThirdObject5 = new MapThirdObject();
            ThirdObject6 = new MapThirdObject();
        }

        public MapSecondObject()
        {
        }
    }
}
