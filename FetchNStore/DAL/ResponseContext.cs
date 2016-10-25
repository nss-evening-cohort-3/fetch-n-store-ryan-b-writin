using FetchNStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FetchNStore.DAL
{
    public class ResponseContext : DbContext
    {
        public virtual DbSet<Response> responses { get; set; }
    }
}