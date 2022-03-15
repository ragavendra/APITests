using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using NUnit.Framework;

namespace AppName
{
    public class PostTests : TestFixture
    {

        [TestCase(TestName = "Get all posts"), Order(0)]
        public void getAllPosts() 
        {
            Post post = new Post();
            post.getAllPosts();
            var respo = post.Get();
            var iIndex = 0;

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var resp = JsonSerializer.Deserialize<List<Models.Post>>(respo.response);

            //JObject

            //JObject resp = JObject.Parse(respo.response);

            foreach (var post_ in resp)
                iIndex++;
                //Assert.AreEqual(post_.title, route, $"Route no filter is not working for {route}");
            //Assert.AreEqual(resp["statusCode"].ToString(), "200", "Status code is not 200");
            //Assert.IsNull(((Newtonsoft.Json.Linq.JValue)resp["error"]).Value, "Error is not null");

            TestContext.WriteLine($"There are {iIndex} posts");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Get post by userId"), Order(0)]
        public void getPostByUserId() 
        {
            Post post = new Post();
            var userId = 1;
            post.getPostByUserId(userId.ToString());
            var respo = post.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var resp = JsonSerializer.Deserialize<List<Models.Post>>(respo.response);
            /*
            JObject resp = JObject.Parse(respo.response);
            */

            foreach (Models.Post post_ in resp)
                Assert.AreEqual(post_.userId, userId, $"Invalid post {post_.userId} for user {userId}");
            //Assert.AreEqual(resp["statusCode"].ToString(), "200", "Status code is not 200");
            //Assert.IsNull(((Newtonsoft.Json.Linq.JValue)resp["error"]).Value, "Error is not null");

            //TestContext.WriteLine($"There are {iIndex} posts");
            System.Threading.Thread.Sleep(1000);

        }
    }
}
