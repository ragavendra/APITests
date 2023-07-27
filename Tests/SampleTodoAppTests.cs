using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using NUnit.Framework;
using ApiTests.Apps;
using ApiTests.Models;

namespace ApiTests.Tests
{
    public class SampleTodoAppTests : TestFixture
    {

        [TestCase(TestName = "Get all posts"), Order(0)]
        public void getAllPosts() 
        {
            SampleTodoApp post = new SampleTodoApp();
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

        [TestCase(TestName = "Get post by userId"), Order(2)]
        public void getPostByUserId() 
        {
            SampleTodoApp post = new SampleTodoApp();
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

        [TestCase(TestName = "Create a post"), Order(6)]
        public void createPost() 
        {
            SampleTodoApp post = new SampleTodoApp();
            var userId = 1;
            var title = "Title";
            var body = "Body of the post goes here";
            post.createPost(title, body, userId);
            var respo = post.Post();

            Assert.AreEqual(HttpStatusCode.Created, respo.status, "Status code is not 200");

            var resp = JsonSerializer.Deserialize<Models.Post>(respo.response);

            Assert.AreEqual(resp.userId, userId, $"Invalid post {resp.userId} for user {userId}");
            Assert.AreEqual(resp.title, title, $"Invalid post {resp.title}");
            Assert.AreEqual(resp.body, body, $"Invalid post {resp.body}");

            System.Threading.Thread.Sleep(1000);

        }
    }
}
