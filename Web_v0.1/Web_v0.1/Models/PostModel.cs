using Infrastructure_v0;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web_v0._1.Models
{
    public class PostModel
    {
        public string Username { get; set; }
        public int AccountId { get; set; }
        public string BeerName { get; set; }
        public int BeerId { get; set; }
        public string BarName { get; set; }
        public int BarId { get; set; }
        public string Description { get; set; }
        public byte Rating { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public interface IPostRepository
    {
        List<PostModel> FrontPagePosts();
        bool AddPost(PostViewModel pvm);
    }

    public class PostRepository : IPostRepository
    {

        public List<PostModel> FrontPagePosts()
        {
            List<PostModel> posts = new List<PostModel>();

            GetData getPosts = new GetFrontPagePosts();
            DataTable ds = getPosts.Execute().Tables[0];

            foreach (DataRow row in ds.Rows)
            {
                PostModel post = new PostModel()
                {
                    Username = row["Username"].ToString(),
                    AccountId = (int) row["accountId"],
                    BeerName = row["beerName"].ToString(),
                    BeerId = (int) row["beerId"],
                    BarName = row["barName"].ToString(),
                    BarId = (int)row["barId"],
                    Description = row["Description"].ToString(),
                    Rating = (byte) row["Rating"],
                    TimeStamp = (DateTime) row["TimeStamp"]
                };
                posts.Add(post);
            }
            return posts;
        }


        public bool AddPost(PostViewModel pvm)
        {
            bool wasSuccess = false;

            CreateData newPost = new CreatePost(1, pvm.SelectedBeer, pvm.SelectedBar, pvm.Rating, pvm.Description, DateTime.Now);
            wasSuccess = newPost.DoInsert();

            return wasSuccess;
        }
    }
}