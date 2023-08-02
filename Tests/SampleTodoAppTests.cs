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
        // Sample GET call - all posts
        [TestCase(TestName = "Get all posts"), Order(0)]
        public void getAllPosts() 
        {
            // Arrange
            SampleTodoApp post = new SampleTodoApp();

            // assign Get All Posts End Point
            post.getAllPosts();

            // Act
            // perform GET
            var respo = post.Get();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var iIndex = 0;

            // Deserialize JSON string to .Net model object
            var resp = JsonSerializer.Deserialize<List<Models.Post>>(respo.response);

            foreach (var post_ in resp)
            {
                iIndex++;
            }   

            //Assert.AreEqual(post_.title, route, $"Route no filter is not working for {route}");
            //Assert.AreEqual(resp["statusCode"].ToString(), "200", "Status code is not 200");

            TestContext.WriteLine($"There are {iIndex} posts");
        }

        // Sample GET call - posts by user
        [TestCase(TestName = "Get post by userId"), Order(2)]
        public void getPostByUserId() 
        {
            // Arrange
            SampleTodoApp post = new SampleTodoApp();
            var userId = 1;
            post.getPostByUserId(userId.ToString());

            // Act
            var respo = post.Get();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var resp = JsonSerializer.Deserialize<List<Models.Post>>(respo.response);

            foreach (Models.Post post_ in resp)
            {
                Assert.AreEqual(post_.userId, userId, $"Invalid post {post_.userId} for user {userId}");
            }
        }

        // Sample POST call
        [TestCase(TestName = "Create a post"), Order(6)]
        public void createPost() 
        {

            // Arrange
            SampleTodoApp post = new SampleTodoApp();

            // Prepare the message body
            var userId = 1;
            var title = "Title";
            var body = "Body of the post goes here";
            post.createPost(title, body, userId);

            // Act
            // Perform POST
            var respo = post.Post();

            // Assert
            // Assert response code
            Assert.AreEqual(HttpStatusCode.Created, respo.status, "Status code is not 200");

            // Deserialize JSON string to .Net model object
            var resp = JsonSerializer.Deserialize<Models.Post>(respo.response);

            // Verify the JSON response
            Assert.AreEqual(resp.userId, userId, $"Invalid post {resp.userId} for user {userId}");
            Assert.AreEqual(resp.title, title, $"Invalid post {resp.title}");
            Assert.AreEqual(resp.body, body, $"Invalid post {resp.body}");
        }
    }
}
