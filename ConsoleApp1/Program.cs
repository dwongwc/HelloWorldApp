using AutoMapper;
using ConsoleApp1.Models;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //AutoMapper Case 1: From A to B (all property are same) 
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<A, B>());
            //var mapper = config.CreateMapper();
            //var a = new A
            //{
            //    Id = 1,
            //    Name = "Name A"
            //};
            //var b = mapper.Map<B>(a);

            //AutoMapper Case 2: From A to B (a property is different) 
            //var config = new MapperConfiguration(
            //    cfg => cfg.CreateMap<A, C>().ForMember(x => x.RowId, y => y.MapFrom(o => o.Id))
            //);
            //var mapper = config.CreateMapper();
            //var a = new A
            //{
            //    Id = 1,
            //    Name = "Name A"
            //};
            //var c = mapper.Map<C>(a);


            var config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<A, B>();
                    cfg.CreateMap<A, C>().ForMember(x => x.RowId, y => y.MapFrom(o => o.Id));
                    }
            );
            var mapper = config.CreateMapper();
            var a = new A
            {
                Id = 1,
                Name = "Name A"
            };
            var b = mapper.Map<B>(a);
            var c = mapper.Map<C>(a);

        }
    }
}
