using FetchNStore.DAL;
using FetchNStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FetchNStore.Controllers
{
    public class ResponseController : ApiController
    {
        ResponseRepository repo = new ResponseRepository();
        // GET api/<controller>
        public IEnumerable<Response> Get()
        {
            return repo.FetchAll();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]dynamic newResponse)
        {
            DateTime SentDate = newResponse.sendDate.Value;
            string UrlToStore = newResponse.url.Value;
            string MethodToStore = newResponse.method.Value;
            int CodeAsInt = (int)newResponse.code.Value;
            int TimeAsInt = (int)newResponse.responseTime.Value;

            Response ResponseToSave = new Response
            {
                URL = UrlToStore,
                Method = MethodToStore,
                Code = CodeAsInt,
                ResponseTime = TimeAsInt,
                SendDate = SentDate
            };
            repo.AddResponse(ResponseToSave);
        }

        // DELETE api/<controller>/5
        public void Delete()
        {
            repo.ClearAll();
        }
    }
}