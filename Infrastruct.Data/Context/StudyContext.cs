using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Infrastruct.Data.Mappings;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastruct.Data.Context
{
    public class StudyContext : DbContext
    {
        DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 定义要使用的数据库
            //正确的是这样，直接连接字符串即可
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            //我是读取的文件内容，为了数据安全
            optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"));
        }
    }
}
