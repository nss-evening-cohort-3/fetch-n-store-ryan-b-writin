using FetchNStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FetchNStore.DAL
{
    public class ResponseRepository
    {
        public ResponseContext Context { get; set; }

        public ResponseRepository(ResponseContext context)
        {
            this.Context = context;
        }
        public ResponseRepository()
        {
            this.Context = new ResponseContext();
        }
        public List<Response> FetchAll()
        {
            return Context.responses.ToList();
        }

        public void AddResponse(Response newResponse)
        {
            Context.responses.Add(newResponse);
            Context.SaveChanges();

        }
        public void ClearAll()
        {
            Context.responses.RemoveRange(Context.responses);
            Context.SaveChanges();
        }
    }
}