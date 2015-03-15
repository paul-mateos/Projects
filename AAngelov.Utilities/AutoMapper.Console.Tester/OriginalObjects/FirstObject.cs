using System;
using System.Collections.Generic;

namespace AutoMapper.Console.Tester.OriginalObjects
{
    public class FirstObject
    {
        public FirstObject()
        {
        }

        public FirstObject(string firstName, string secondName, string poNumber, decimal price, DateTime skipDateTime, SecondObject secondObjectEntity)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.PoNumber = poNumber;
            this.Price = price;
            this.SkipDateTime = skipDateTime;
            this.SecondObjectEntity = secondObjectEntity;
            SecondObjects = new List<SecondObject>();
            SecondObjects.Add(new SecondObject());
            SecondObjects.Add(new SecondObject());
            SecondObjects.Add(new SecondObject());
            IntCollection = new List<int>()
            {
                1, 5, 6
            };
            IntArr = new int[]
            {
                1, 2, 3
            };
            SecondObjectArr = new SecondObject[]
            {
                new SecondObject()
            };
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PoNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime SkipDateTime { get; set; }
        public SecondObject SecondObjectEntity { get; set; }
        public List<SecondObject> SecondObjects { get; set; }
        public List<int> IntCollection { get; set; }
        public int[] IntArr { get; set; }
        public SecondObject[] SecondObjectArr { get; set; }
    }
}
