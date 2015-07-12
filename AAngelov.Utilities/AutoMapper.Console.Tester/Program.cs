using System;
using System.Collections.Generic;
using System.Diagnostics;
using AAngelov.Utilities.Test;
using AutoMapper.Console.Tester.MapObjects;
using AutoMapper.Console.Tester.OriginalObjects;

namespace AutoMapper.Console.Tester
{
    public class Program
    {
        static void Main(string[] args)
        {
            Profile("Test Reduced AutoMapper 10 Runs 10k Objects", 10, () => MapObjectsReduceAutoMapper());
            Profile("Test Original AutoMapper 10 Runs 10k Objects", 10, () => MapObjectsAutoMapper());
            System.Console.ReadLine();
        }

        static void Profile(string description, int iterations, Action actionToProfile)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                actionToProfile();
            }
            watch.Stop();
            System.Console.WriteLine(description);
            System.Console.WriteLine("Total: {0:0.00} ms ({1:N0} ticks) (over {2:N0} iterations)",
                watch.ElapsedMilliseconds, watch.ElapsedTicks, iterations);
            var avgElapsedMillisecondsPerRun = watch.ElapsedMilliseconds / iterations;
            var avgElapsedTicksPerRun = watch.ElapsedMilliseconds / iterations;
            System.Console.WriteLine("AVG: {0:0.00} ms ({1:N0} ticks) (over {2:N0} iterations)",
                avgElapsedMillisecondsPerRun, avgElapsedTicksPerRun, iterations);
        }

        static void MapObjectsReduceAutoMapper()
        {
            List<FirstObject> firstObjects = new List<FirstObject>();
            List<MapFirstObject> mapFirstObjects = new List<MapFirstObject>();

            ReducedAutoMapper.Instance.CreateMap<FirstObject, MapFirstObject>();
            ReducedAutoMapper.Instance.CreateMap<SecondObject, MapSecondObject>();
            ReducedAutoMapper.Instance.CreateMap<ThirdObject, MapThirdObject>();
            for (int i = 0; i < 10000; i++)
            {
                FirstObject firstObject =
                    new FirstObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)12.2, DateTime.Now,
                        new SecondObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)11.2));
                firstObjects.Add(firstObject);
            }
            foreach (var currentObject in firstObjects)
            {
                MapFirstObject mapSecObj = ReducedAutoMapper.Instance.Map<FirstObject, MapFirstObject>(currentObject);
                mapFirstObjects.Add(mapSecObj);
            }
        }

        static void MapObjectsAutoMapper()
        {
            List<FirstObject> firstObjects = new List<FirstObject>();
            List<MapFirstObject> mapFirstObjects = new List<MapFirstObject>();

            AutoMapper.Mapper.CreateMap<FirstObject, MapFirstObject>();
            AutoMapper.Mapper.CreateMap<SecondObject, MapSecondObject>();
            AutoMapper.Mapper.CreateMap<ThirdObject, MapThirdObject>();
            for (int i = 0; i < 10000; i++)
            {
                FirstObject firstObject =
                    new FirstObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)12.2, DateTime.Now,
                        new SecondObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), (decimal)11.2));
                firstObjects.Add(firstObject);
            }
            foreach (var currentObject in firstObjects)
            {
                MapFirstObject mapSecObj = AutoMapper.Mapper.Map<FirstObject, MapFirstObject>(currentObject);
                mapFirstObjects.Add(mapSecObj);
            }
        }
    }
}