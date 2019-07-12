using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappTest.ListTest
{
    public class Source
    {
        public int Value { get; set; }
    }

    public class Destination
    {
        public int Value { get; set; }
    }
    public static class ListTest
    {
        public static void Test1()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>());

            var sources = new List<Source>()
                {

                    new Source { Value = 5 },
                    new Source { Value = 6 },
                    new Source { Value = 7 }
            };
            var mapper = configuration.CreateMapper();
            IEnumerable<Destination> ienumerableDest = mapper.Map<List<Source>, IEnumerable<Destination>>(sources);
            ICollection<Destination> icollectionDest = mapper.Map<List<Source>, ICollection<Destination>>(sources);
            IList<Destination> ilistDest = mapper.Map<List<Source>, IList<Destination>>(sources);
            List<Destination> listDest = mapper.Map<List<Source>, List<Destination>>(sources);
            Destination[] arrayDest = mapper.Map<List<Source>, Destination[]>(sources);
            Console.WriteLine($"ListTest test1 size:{arrayDest.Length}");
        }

        public static void TestNull()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                //如果设置了, 当源为NULL时, 生成的目标也为NULL, 不设置目标为空,但不为NULL
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Source, Destination>();
            });
            List<Source> sources = null;
            var mapper = configuration.CreateMapper();
            List<Destination> listDest = mapper.Map<List<Source>, List<Destination>>(sources);
            Console.WriteLine($"ListTest test1 size:{listDest.Count}");
        }
    }
}
