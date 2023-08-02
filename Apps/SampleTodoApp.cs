using ApiTests.Models;
using System.Text.Json;

namespace ApiTests.Apps
{
    public class SampleTodoApp : Rest
    {
        
        private readonly string _serverName;

        private readonly string _protocol;

        public SampleTodoApp()
        {
            _serverName = Constants.eotServerName;
            _protocol = Constants.protocol;
            SetBaseUrl();
        }

        private void SetBaseUrl()
        {
            _url = string.Format("{0}://{1}", _protocol, _serverName);
        }

        //GET calls
        public void getAllPosts()
        {
            SetBaseUrl();
            _url = _url + "/posts";
        }

        public void getPostById(string postId)
        {
            SetBaseUrl();
            _url = _url + $"/posts/{postId}";
        }

        public void getPostByUserId(string userId = "")
        {
            SetBaseUrl();
            _url = _url + "/posts";

            if (userId != "")
            {
                _url = _url + $"?userId={userId}";
            }
        }

        public void getCommentsForPost(string postId = "")
        {
            SetBaseUrl();
            _url = _url + "/posts";

            if (postId != "")
            {
                _url = _url + $"/{postId}/1/comments";
            }
        }

        public void createPost(string title, string body, int userId)
        {
            SetBaseUrl();
            _url = _url + "/posts";

            Post post = new Post() { title = title, body = body, userId = userId};

            _message = JsonSerializer.Serialize(post);
        }
    }
}
