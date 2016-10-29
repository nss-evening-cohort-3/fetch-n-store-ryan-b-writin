using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FetchNStore.DAL;
using FetchNStore.Models;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace FetchNStore.Tests
{
    [TestClass]
    public class ResponseTests
    {
        Mock<ResponseContext> mock_context { get; set; }
        Mock<DbSet<Response>> mock_response_table { get; set; }
        List<Response> responseList { get; set; }
        ResponseRepository repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var queryable_list = responseList.AsQueryable();

            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_response_table.As<IQueryable<Response>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(c => c.responses).Returns(mock_response_table.Object);

            mock_response_table.Setup(t => t.Add(It.IsAny<Response>())).Callback((Response a) => responseList.Add(a));
            mock_response_table.Setup(t => t.Remove(It.IsAny<Response>())).Callback((Response a) => responseList.Remove(a));
            mock_response_table.Setup(t => t.RemoveRange(It.IsAny<IEnumerable<Response>>())).Callback((IEnumerable<Response> a) => responseList.RemoveRange(0, a.Count<Response>()));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ResponseContext>();
            mock_response_table = new Mock<DbSet<Response>>();
            responseList = new List<Response>();
            repo = new ResponseRepository(mock_context.Object);
        }
        [TestCleanup]
        public void Teardown()
        {
            repo = null;
        }

        [TestMethod]
        public void RepoCreateInstanceOfResponseRepo()
        {
            Assert.IsNotNull(repo);
        }
        [TestMethod]
        public void RepoHasContext()
        {
            Assert.IsNotNull(repo.Context);
        }
        [TestMethod]
        public void RepoHasNoResponses()
        {
            ConnectMocksToDatastore();

            List<Response> responses = repo.FetchAll();
            int expected_response_count = 0;
            int actual_response_count = responses.Count;

            Assert.AreEqual(expected_response_count, actual_response_count);
        }
        [TestMethod]
        public void RepoCanAddStoreResponse()
        {
            ConnectMocksToDatastore();
            Response newResponse = new Response {
                URL = "hello",
                Method = "yes",
                Code = 200,
                ResponseTime = 30,
                SendDate = new DateTime() 
            };

            repo.AddResponse(newResponse);

            int actual_response_count = repo.FetchAll().Count;
            int expected_response_count = 1;

            Assert.AreEqual(expected_response_count, actual_response_count);
        }
        [TestMethod]
        public void RepoCanFetchResponses()
        {
            responseList.Add(new Response
            {
                URL = "hello",
                Method = "yes",
                Code = 200,
                ResponseTime = 30,
                SendDate = new DateTime()
            });
            responseList.Add(new Response
            {
                URL = "hello",
                Method = "yes",
                Code = 200,
                ResponseTime = 30,
                SendDate = new DateTime()
            });
            responseList.Add(new Response
            {
                URL = "hello",
                Method = "yes",
                Code = 200,
                ResponseTime = 30,
                SendDate = new DateTime()
            });
            ConnectMocksToDatastore();

            var expected_response_list = responseList; 
            var actual_response_list = repo.FetchAll();

            CollectionAssert.AreEqual(expected_response_list, actual_response_list);
        }
        [TestMethod]
        public void RepoCanClearAll()
        {
            responseList.Add(new Response
            {
                URL = "hello",
                Method = "yes",
                Code = 200,
                ResponseTime = 30,
                SendDate = new DateTime()
            });
            responseList.Add(new Response
            {
                URL = "hello",
                Method = "yes",
                Code = 200,
                ResponseTime = 30,
                SendDate = new DateTime()
            });
            responseList.Add(new Response
            {
                URL = "hello",
                Method = "yes",
                Code = 200,
                ResponseTime = 30,
                SendDate = new DateTime()
            });
            ConnectMocksToDatastore();

            repo.ClearAll();
            int expected_response_count = 0;
            int actual_response_count = repo.FetchAll().Count;

            Assert.AreEqual(expected_response_count, actual_response_count);
        }
    }
}
