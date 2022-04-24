using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp1.Application.UnitTest.AppUsers.Commands
{
    public class CreateAppUserTest
    {
        private readonly Mock<ICitiesRepository> _mockRepository;

        public CreateAppUserTest()
        {
            _mockRepository = new RepositoryMocks.GetCitiesRepository();


        }

        [Fact]
        public async Task Handle_ValidPost_AddedToPostRepo()
        {
            var handler = new CreatedPostCommandHandler
                (_mockPostRepository.Object, _mapper);

            var allPostsBeforeCount = (await _mockPostRepository.Object.GetAllAsync()).Count;

            var command = new CreatedPostCommand()
            {
                Title ="TestTest",
                Date = DateTime.Now.AddDays(-14),
                Rate = 9,
                Author = "AAAA"
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allPosts = await _mockPostRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allPosts.Count.ShouldBe(allPostsBeforeCount + 1);
            response.PostId.ShouldNotBeNull();
        }

        [Fact]
    public async Task Handle_Not_ValidPost_TooLongTitle_81Characters_NotAddedToPostRepo()
    {
        var handler = new CreatedPostCommandHandler
            (_mockPostRepository.Object, _mapper);

        var allPostsBeforeCount = (await _mockPostRepository.Object.GetAllAsync()).Count;

        var command = new CreatedPostCommand()
        {
            Title = new string("*", 81),
            Date = DateTime.Now.AddDays(-14),
            Rate = 9,
            Author = "AAAA"
        };

        var response = await handler.Handle(command, CancellationToken.None);

        var allPosts = await _mockPostRepository.Object.GetAllAsync();

        response.Success.ShouldBe(false);
        response.ValidationErrors.Count.ShouldBe(1);
        allPosts.Count.ShouldBe(allPostsBeforeCount);
        response.PostId.ShouldBeNull();
    }
    }
}