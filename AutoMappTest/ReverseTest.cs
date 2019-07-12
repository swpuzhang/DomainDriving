using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappTest.Reverse
{
    public class Order
    {
        public decimal Total { get; set; }
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
    }

    public class OrderDto
    {
        public decimal Total { get; set; }
        public string CustomerName { get; set; }
    }

    public static class ReverseTest
    {
        public static void Test()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>()
                   .ReverseMap();
            });
            var customer = new Customer
            {
                Name = "Bob"
            };

            var order = new Order
            {
                Customer = customer,
                Total = 15.8m
            };

            var mapper = configuration.CreateMapper();
            var orderDto = mapper.Map<Order, OrderDto>(order);

            orderDto.CustomerName = "Joe";
            
            mapper.Map(orderDto, order);
            configuration.AssertConfigurationIsValid();
            Console.WriteLine($"ReverseTest test {order.Customer.Name}");
            Console.WriteLine($"ReverseTest test {orderDto.Total} {orderDto.CustomerName}");

        }

        public static void Test1()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>()
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ReverseMap()
                .ForPath(s => s.Customer.Name, opt => opt.Ignore());
                // .ForPath(s => s.Customer.Name, opt => opt.MapFrom(src => src.CustomerName));
            });
            var customer = new Customer
            {
                Name = "Bob"
            };

            var order = new Order
            {
                Customer = customer,
                Total = 15.8m
            };

            var mapper = configuration.CreateMapper();
            var orderDto = mapper.Map<Order, OrderDto>(order);

            orderDto.CustomerName = "Joe";

            mapper.Map(orderDto, order);
            configuration.AssertConfigurationIsValid();
            Console.WriteLine($"ReverseTest test {order.Customer.Name}");
            Console.WriteLine($"ReverseTest test {orderDto.Total} {orderDto.CustomerName}");

        }
    }
}
