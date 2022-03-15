using AppName.Models;
using Newtonsoft.Json;

namespace AppName
{
    public class Post : Rest
    {
        
        private string serverName = Constants.eotServerName;
        private const string protocol = Constants.protocol;

        //GET calls
        public void getAllPosts()
        {
            URLi = $"{protocol}://{serverName}/posts";
        }

        public void getPostByUserId(string userId = "")
        {
            URLi = $"{protocol}://{serverName}/posts";

            if (userId == "")
                return;
            else
                URLi = URLi + $"?userId={userId}";
        }

        public void getCommentsForPost(string postId = "")
        {
            URLi = $"{protocol}://{serverName}/posts";

            if (postId == "")
                return;
            else
                URLi = URLi + $"/{postId}/1/comments";
        }

        public void createPost(string title, string body, int userId)
        {
            URLi = $"{protocol}://{serverName}/posts";

            Models.Post post = new Models.Post();
            post.title = title;
            post.body = body;
            post.userId = userId;

            sMessage = JsonConvert.SerializeObject(post);
        }


    }
}
