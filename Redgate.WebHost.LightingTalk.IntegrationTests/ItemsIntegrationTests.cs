using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Redgate.WebHost.LightingTalk.Data;
using Redgate.WebHost.LightingTalk.IntegrationTests.Utility;

namespace Redgate.WebHost.LightingTalk.IntegrationTests
{
    public class ItemsTests
    {
        private CustomWebApplicationFactory m_WebApplicationFactory;
        
        [SetUp]
        public void Setup()
        {
            m_WebApplicationFactory = new CustomWebApplicationFactory();
        }

        [Test]
        public async Task s()
        {
            var client = m_WebApplicationFactory.CreateClient();
            var result= await client.GetAsync("api/items");
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            (await result.Content.ReadFromJsonAsync<IEnumerable<string>>()).Should()
                .BeEquivalentTo(InMemoryDatabaseHelper.InMemoryItems.Select(x => x.Value));
        }

        [Test]
        public async Task AddItem_ShouldAddNewItem()
        {
            var itemValue = "NewITem";
            var client = m_WebApplicationFactory.CreateClient();
            var result = await client.PostAsync("api/Items/Add", JsonContent.Create(itemValue));
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var getResult = await client.GetAsync("api/items");
            getResult.StatusCode.Should().Be(HttpStatusCode.OK);
            InMemoryDatabaseHelper.InMemoryItems.Add(new Item { Id = Guid.NewGuid(), Value = itemValue });
            (await getResult.Content.ReadFromJsonAsync<IEnumerable<string>>()).Should()
                .BeEquivalentTo(InMemoryDatabaseHelper.InMemoryItems.Select(x => x.Value));
        }
    }
}