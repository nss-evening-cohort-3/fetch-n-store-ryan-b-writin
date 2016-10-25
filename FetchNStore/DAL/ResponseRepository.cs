using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FetchNStore.DAL
{
    public class ResponseRepository
    {
        public ResponseContext context { get; set; }

        public ResponseRepository(ResponseContext context)
        {
            this.context = context;
        }
    }
}