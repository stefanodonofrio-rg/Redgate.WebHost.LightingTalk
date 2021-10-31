using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace Redgate.WebHost.LightingTalk.IntegrationTests
{
    public class ItemsIntegrationTests
    {
        private WebApplicationFactory<Startup> m_WebApplicationFactory;
        
        [SetUp]
        public void Setup()
        {
            m_WebApplicationFactory = new WebApplicationFactory<Startup>();
        }

        [Test]
        public async Task GetItem_ShouldReturnOk()
        {
            var client = m_WebApplicationFactory.CreateClient();
            var result= await client.GetAsync("api/items");
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}