using SimpleBlog.API.Infrastructure;
using FakeItEasy;
using Xunit;
using SimpleBlog.API.Controllers;
using SimpleBlog.API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace SimpleBlog.API.Tests
{
    public class PostsRepositoryTests
    {
        protected IPostsRepository FakePostsRepository;
        protected PostsController FakePostsController;


        [Fact]
        public void PostsRepository_HasPosts()
        {
            //  Arrange
            var postsRepository = new PostsRepository(new WebClient(new HttpClient()));

            //  Act
            var result = postsRepository.GetAll<Post>();

            //  Assert
            Assert.True(result.Result.Count > 0);
        }

        [Fact]
        public void PostsRepository_Can_Get_Post_By_Id()
        {
            //  Arrange
            var postsRepository = new PostsRepository(new WebClient(new HttpClient()));

            //  Act
            var result = postsRepository.Get<Post>(6);

            //  Assert
            Assert.True(result.Result.Id == 6);
            Assert.True(result.Result.Title.Length > 0);
        }

        [Fact]
        public void PostsRepository_Can_Get_Post_By_Number()
        {
            //  Arrange
            var postsRepository = new PostsRepository(new WebClient(new HttpClient()));

            //  Act
            var result = postsRepository.GetN<Post>(2);

            //  Assert
            Assert.True(result.Result.Count == 2);
        }

        [Fact]
        public void PostsRepository_Post_Only_By_Valid_Id()
        {
            //  Arrange
            var postsRepository = new PostsRepository(new WebClient(new HttpClient()));

            //  Act
            var result = postsRepository.Get<Post>(-10);

            //  Assert
            Assert.True(result.Result == null);
        }

        [Fact]
        public void PostsRepository_HasComments()
        {
            //  Arrange
            var commentsRepository = new CommentsRepository(new WebClient(new HttpClient()));

            //  Act
            var result = commentsRepository.GetAll<IList<Comment>>(6);
            
            //  Assert
            Assert.True(result.Result.Count > 0);
        }

    }
}