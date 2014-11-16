using AAngelov.Utilities.Test;
using AAngelov.Utilities.Test.Validators;
using AAngelov.Utilities.Test.Validators.Enums;
using AutoMapper.Console.Tester.MapObjects;
using AutoMapper.Console.Tester.OriginalObjects;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper.Console.Tester.Validators;

namespace AutoMapper.Console.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime startTime = DateTime.Now;
            //List<FirstObject> firstObjects = new List<FirstObject>();
            //List<MapFirstObject> mapFirstObjects = new List<MapFirstObject>();

            //CustomAutoMapper.Instance.CreateMap<FirstObject, MapFirstObject>();
            //CustomAutoMapper.Instance.CreateMap<SecondObject, MapSecondObject>();
            //CustomAutoMapper.Instance.CreateMap<ThirdObject, MapThirdObject>();
            //for (int i = 0; i < 10000; i++)
            //{
            //    FirstObject firstObject =
            //      new FirstObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)12.2, DateTime.Now,
            //      new SecondObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)11.2));
            //    firstObjects.Add(firstObject);
            //    System.Console.WriteLine("Object created: {0}", i);
            //}
            //for (int i = 0; i < firstObjects.Count; i++)
            //{
            //    MapFirstObject mapSecObj = CustomAutoMapper.Instance.Map<FirstObject, MapFirstObject>(firstObjects[i]);
            //    mapFirstObjects.Add(mapSecObj);
            //    System.Console.WriteLine("Map Object: {0}", i);
            //}

            ////FirstObject firstObject =
            ////      new FirstObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)12.2, DateTime.Now,
            ////      new SecondObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)11.2));

            ////MapFirstObject mapSecObj = CustomAutoMapper.Instance.Map<FirstObject, MapFirstObject>(firstObject);
            ////mapFirstObjects.Add(mapSecObj);

            //AutoMapper.Mapper.CreateMap<FirstObject, MapFirstObject>();
            //AutoMapper.Mapper.CreateMap<SecondObject, MapSecondObject>();
            //AutoMapper.Mapper.CreateMap<ThirdObject, MapThirdObject>();
            //for (int i = 0; i < 10000; i++)
            //{
            //    FirstObject firstObject =
            //      new FirstObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)12.2, DateTime.Now,
            //      new SecondObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)11.2));
            //    firstObjects.Add(firstObject);
            //    System.Console.WriteLine("Object created: {0}", i);
            //}
            //for (int i = 0; i < firstObjects.Count; i++)
            //{
            //    MapFirstObject mapSecObj = AutoMapper.Mapper.Map<FirstObject, MapFirstObject>(firstObjects[i]);
            //    mapFirstObjects.Add(mapSecObj);
            //    System.Console.WriteLine("Map Object: {0}", i);
            //}

            //DateTime endTime = DateTime.Now;
            //System.Console.WriteLine("Finish for {0}", endTime - startTime);
            DateTimeAssert.Validate( 
                new DateTime(2014, 10, 10, 20, 22, 16),
                new DateTime(2014, 10, 11, 20, 22, 16),
                DateTimeDeltaType.Days,
                1);

            ObjectToAssert expectedObject = new ObjectToAssert()
            {
                FirstName = "Anton",
                PoNumber = "TestPONumber",
                LastName = "Angelov",
                Price = 12.3M,
                SkipDateTime = new DateTime(1989, 10, 28)
            };

            ObjectToAssert actualObject = new ObjectToAssert()
            {
                FirstName = "AntonE",
                PoNumber = "TestPONumber",
                LastName = "Angelov",
                Price = 12.3M,
                SkipDateTime = new DateTime(1989, 10, 28)
            };

            Assert.AreEqual<string>(expectedObject.FirstName, actualObject.FirstName, "The first name was not as expected.");
            Assert.AreEqual<string>(expectedObject.LastName, actualObject.LastName, "The last name was not as expected.");
            Assert.AreEqual<string>(expectedObject.PoNumber, actualObject.PoNumber, "The PO Number was not as expected.");
            Assert.AreEqual<decimal>(expectedObject.Price, actualObject.Price, "The price was not as expected.");
            DateTimeAssert.Validate(
            expectedObject.SkipDateTime,
            actualObject.SkipDateTime,
            DateTimeDeltaType.Days,
            1);

            ObjectToAssertValidator.Instance.Validate(expectedObject, actualObject);
        }
    }
}
