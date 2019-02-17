using SimpleBlog.API.Infrastructure;
using Xunit;
using SimpleBlog.API.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace SimpleBlog.API.Tests.Infrastructure.Repositories
{
    public class CommentsRepositoryTests
    {
        [Fact]
        public void CommentsRepository_Can_Get_Comments_By_Number()
        {
            //  Arrange
            var commentsRepository = new CommentsRepository(new WebClient(new HttpClient()));

            //  Act
            var result = commentsRepository.GetN<IList<Comment>>(6, 4);

            //  Assert
            Assert.True(result.Result.Count == 4);
        }

        [Fact]
        public void CommentsRepository_Comments_Only_By_Valid_Id()
        {
            //  Arrange
            var commentsRepository = new CommentsRepository(new WebClient(new HttpClient()));

            //  Act
            var result = commentsRepository.GetAll<IList<Comment>>(-100);

            //  Assert
            Assert.True(result.Result.Count == 0);

        }

    }
}
