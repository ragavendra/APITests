using ApiTests.Models;
using System.Text.Json;

namespace ApiTests.Apps
{
    public class SampleTodoApp : Rest
    {
        
        private string _serverName = Constants.eotServerName;

        private const string _protocol = Constants.protocol;

        //GET calls
        public void getAllPosts()
        {
            _url = string.Format("{0}://{1}/posts", _protocol, _serverName);
        }

        public void getPostByUserId(string userId = "")
        {
            _url = $"{_protocol}://{_serverName}/posts";

            if (userId == "")
            {
                return;
            }
            else
            {
                _url = _url + $"?userId={userId}";
            }
        }

        public void getCommentsForPost(string postId = "")
        {
            _url = $"{_protocol}://{_serverName}/posts";

            if (postId == "")
            {
                return;
            }
            else
            {
                _url = _url + $"/{postId}/1/comments";
            }
        }

        public void createPost(string title, string body, int userId)
        {
            _url = $"{_protocol}://{_serverName}/posts";

            Post post = new Post() { title = title, body = body, userId = userId};

            _message = JsonSerializer.Serialize(post);
        }


    }
}
