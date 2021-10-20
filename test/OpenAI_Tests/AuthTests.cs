using NUnit.Framework;
using System;
using System.IO;

namespace OpenAI_Tests
{
	public class AuthTests
	{
		[SetUp]
		public void Setup()
		{
			File.WriteAllText(".openai", "OPENAI_KEY=pk-test12");
			Environment.SetEnvironmentVariable("OPENAI_KEY", "pk-test-env");
			//Environment.SetEnvironmentVariable("OPENAI_SECRET_KEY", "sk-test-env");
		}

		[Test]
		public void GetAuthFromEnv()
		{
			var auth = OpenAI.APIAuthentication.LoadFromEnv();
			Assert.IsNotNull(auth);
			Assert.IsNotNull(auth.ApiKey);
			Assert.IsNotEmpty(auth.ApiKey);
			Assert.AreEqual("pk-test-env", auth.ApiKey);
		}

		[Test]
		public void GetAuthFromFile()
		{
			var auth = OpenAI.APIAuthentication.LoadFromPath();
			Assert.IsNotNull(auth);
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual("pk-test12", auth.ApiKey);
		}


		[Test]
		public void GetAuthFromNonExistantFile()
		{
			var auth = OpenAI.APIAuthentication.LoadFromPath(filename: "bad.config");
			Assert.IsNull(auth);
		}


		[Test]
		public void GetDefault()
		{
			var auth = OpenAI.APIAuthentication.Default;
			var envAuth = OpenAI.APIAuthentication.LoadFromEnv();
			Assert.IsNotNull(auth);
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual(envAuth.ApiKey, auth.ApiKey);
		}



		[Test]
		public void testHelper()
		{
			OpenAI.APIAuthentication defaultAuth = OpenAI.APIAuthentication.Default;
			OpenAI.APIAuthentication manualAuth = new OpenAI.APIAuthentication("pk-testAA");
			OpenAI.OpenAIAPI api = new OpenAI.OpenAIAPI();
			OpenAI.APIAuthentication shouldBeDefaultAuth = api.Auth;
			Assert.IsNotNull(shouldBeDefaultAuth);
			Assert.IsNotNull(shouldBeDefaultAuth.ApiKey);
			Assert.AreEqual(defaultAuth.ApiKey, shouldBeDefaultAuth.ApiKey);

			OpenAI.APIAuthentication.Default = new OpenAI.APIAuthentication("pk-testAA");
			api = new OpenAI.OpenAIAPI();
			OpenAI.APIAuthentication shouldBeManualAuth = api.Auth;
			Assert.IsNotNull(shouldBeManualAuth);
			Assert.IsNotNull(shouldBeManualAuth.ApiKey);
			Assert.AreEqual(manualAuth.ApiKey, shouldBeManualAuth.ApiKey);
		}

		[Test]
		public void GetKey()
		{
			var auth = new OpenAI.APIAuthentication("pk-testAA");
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual("pk-testAA", auth.ApiKey);
		}

		[Test]
		public void ParseKey()
		{
			var auth = new OpenAI.APIAuthentication("pk-testAA");
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual("pk-testAA", auth.ApiKey);
			auth = "pk-testCC";
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual("pk-testCC", auth.ApiKey);

			auth = new OpenAI.APIAuthentication("sk-testBB");
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual("sk-testBB", auth.ApiKey);
		}

	}
}