using NUnit.Framework;
using OpenAI;
using System;
using System.IO;
using System.Linq;

namespace OpenAI_Tests
{
	public class SearchEndpointTests
	{
		[SetUp]
		public void Setup()
		{
			OpenAI.APIAuthentication.Default = new OpenAI.APIAuthentication(Environment.GetEnvironmentVariable("TEST_OPENAI_SECRET_KEY"));
		}

		[Test]
		public void TestBasicSearch()
		{
			var api = new OpenAI.OpenAIAPI(engine: Engine.Curie);

			Assert.IsNotNull(api.Search);

			var result = api.Search.GetBestMatchAsync("Washington DC", "Canada", "China", "USA", "Spain").Result;
			Assert.IsNotNull(result);
			Assert.AreEqual("USA", result);
		}

		// TODO: More tests needed but this covers basic functionality at least

	}
}