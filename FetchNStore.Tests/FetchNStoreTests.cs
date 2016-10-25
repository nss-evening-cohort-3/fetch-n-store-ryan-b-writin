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
    }
}
