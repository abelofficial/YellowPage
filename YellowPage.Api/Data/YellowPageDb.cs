using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YellowPage.Api.Models;

    public class YellowPageDb : DbContext
    {
        public YellowPageDb (DbContextOptions<YellowPageDb> options)
            : base(options)
        {
        }

        public DbSet<YellowPage.Api.Models.Person> Person { get; set; }

        public DbSet<YellowPage.Api.Models.Business> Business { get; set; }
    }
