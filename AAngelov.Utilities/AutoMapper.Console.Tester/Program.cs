using System;
using System.Collections.Generic;
using AAngelov.Utilities.Test;
using AutoMapper.Console.Tester.MapObjects;
using AutoMapper.Console.Tester.OriginalObjects;

namespace AutoMapper.Console.Tester
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            List<FirstObject> firstObjects = new List<FirstObject>();
            List<MapFirstObject> mapFirstObjects = new List<MapFirstObject>();

            // REDUCED AUTO MAPPER TEST ------------------------------------------------------------
            ReducedAutoMapper.Instance.CreateMap<FirstObject, MapFirstObject>();
            ReducedAutoMapper.Instance.CreateMap<SecondObject, MapSecondObject>();
            ReducedAutoMapper.Instance.CreateMap<ThirdObject, MapThirdObject>();
            for (int i = 0; i < 100000; i++)
            {
                FirstObject firstObject =
                  new FirstObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)12.2, DateTime.Now,
                  new SecondObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)11.2));
                firstObjects.Add(firstObject);
                System.Console.WriteLine("Object created: {0}", i);
            }
            for (int i = 0; i < firstObjects.Count - 1; i++)
            {
                MapFirstObject mapSecObj = ReducedAutoMapper.Instance.Map<FirstObject, MapFirstObject>(firstObjects[i]);
                mapFirstObjects.Add(mapSecObj);
                System.Console.WriteLine("Map Object: {0}", i);
            }

            // AUTO MAPPER TEST ------------------------------------------------------------
            ////AutoMapper.Mapper.CreateMap<FirstObject, MapFirstObject>();
            ////AutoMapper.Mapper.CreateMap<SecondObject, MapSecondObject>();
            ////AutoMapper.Mapper.CreateMap<ThirdObject, MapThirdObject>();
            ////for (int i = 0; i < 1000; i++)
            ////{
            ////    FirstObject firstObject =
            ////      new FirstObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)12.2, DateTime.Now,
            ////      new SecondObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)11.2));
            ////    firstObjects.Add(firstObject);
            ////    System.Console.WriteLine("Object created: {0}", i);
            ////}
            ////for (int i = 0; i < firstObjects.Count; i++)
            ////{
            ////    MapFirstObject mapSecObj = AutoMapper.Mapper.Map<FirstObject, MapFirstObject>(firstObjects[i]);
            ////    mapFirstObjects.Add(mapSecObj);
            ////    System.Console.WriteLine("Map Object: {0}", i);
            ////}

            DateTime endTime = DateTime.Now;
            System.Console.WriteLine("Finish for {0}", endTime - startTime);
            System.Console.WriteLine();
        }
    }
}
