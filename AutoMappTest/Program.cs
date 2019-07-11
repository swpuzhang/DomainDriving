using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoMappTest
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class PersonDto
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class Order
    {
        private readonly IList<OrderLineItem> _orderLineItems = new List<OrderLineItem>();

        public Customer Customer { get; set; }

        public OrderLineItem[] GetOrderLineItems()
        {
            return _orderLineItems.ToArray();
        }

        public void AddOrderLineItem(Product product, int quantity)
        {
            _orderLineItems.Add(new OrderLineItem(product, quantity));
        }

   
        public decimal GetTotal()
        {
            return _orderLineItems.Sum(li => li.GetTotal());
        }
    }

    public class Product
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }

    public class OrderLineItem
    {
        public OrderLineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }

    public class Customer
    {
        public string Name { get; set; }
    }

    public class OrderDto
    {
        public string CustomerName { get; set; }
        //如果没有匹配上, 那么会加上Get
        public decimal Total { get; set; }
    }

    class Source
    {
        public string Name { get; set; }
        public InnerSource InnerSource { get; set; }
        public OtherInnerSource OtherInnerSource { get; set; }
    }
    class InnerSource
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    class OtherInnerSource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
    class Destination
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    class Program
    {
        static void NormalTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDto>().ReverseMap();

            });
            var mapper = config.CreateMapper();
            Person p = new Person() { Age = 11, Name = "zhangyang" };
            var pdto = mapper.Map<PersonDto>(p);
            Console.WriteLine($" NormalTest {pdto.Age} {pdto.Name}");
        }

        static void Flatttest()
        {
            var customer = new Customer
            {
                Name = "George Costanza"
            };
            var order = new Order
            {
                Customer = customer
            };
            var bosco = new Product
            {
                Name = "Bosco",
                Price = 4.99m
            };
            order.AddOrderLineItem(bosco, 15);

            // Configure AutoMapper

            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>());

            // Perform mapping
            var mapper = configuration.CreateMapper();
            OrderDto dto = mapper.Map<Order, OrderDto>(order);
            Console.WriteLine($" Flatttest {dto.CustomerName} {dto.Total}");
            
        }

        static void IncludeTest()
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                //加上成员进行匹配
                cfg.CreateMap<Source, Destination>().IncludeMembers(s => s.InnerSource, s => s.OtherInnerSource);
                //cfg.CreateMap<InnerSource, Destination>(MemberList.None);
                cfg.CreateMap<InnerSource, Destination>();
                cfg.CreateMap<OtherInnerSource, Destination>(MemberList.None);
            });

            // Perform mapping
            var mapper = configuration.CreateMapper();
           

            var source = new Source
            {
                Name = "name",
                InnerSource = new InnerSource { Description = "description" },
                OtherInnerSource = new OtherInnerSource { Title = "title" }
            };
            var destination = mapper.Map<Destination>(source);
            Console.WriteLine($" Flatttest {destination.Name} {destination.Description} {destination.Title}");
            var InnerSource = new InnerSource
            {
                Name = "name",
                Description = "1111"
            };
            destination = mapper.Map<Destination>(InnerSource);
            Console.WriteLine($" Flatttest {destination.Name} {destination.Description} {destination.Title}");
            //destination.Name.Shou =ldBe("name");
            //destination.Description.ShouldBe("description");
            //destination.Title.ShouldBe("title");
        }

        static void Main(string[] args)
        {
            NormalTest();
            Flatttest();
            IncludeTest();
        }
    }
}
