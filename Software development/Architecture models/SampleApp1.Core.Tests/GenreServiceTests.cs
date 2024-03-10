using SampleApp1.Core.Tests.Utilities.Fixtures;
using SampleApp1.Data.Models;
using TryAtSoftware.Randomizer.Core.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace SampleApp1.Core.Tests
{
    public class GenreServiceTests : BaseTest
    {
        public GenreServiceTests(MySqlDatabaseFixture databaseFixture, ITestOutputHelper outputHelper)
            : base(databaseFixture, outputHelper)
        {
        }

        [Fact]
        public void CreateGenreShouldWorkCorrectly()
        {
            // Arrange
            var genre = new Genre { Name = RandomizationHelper.GetRandomString() };

            // Act
            var create = this.GenreService.Create(genre);

            // Assert
            Assert.True(create, "Genre was not created successfully - it may be invalid.");
            Assert.NotEqual(default, genre.Id);
        }

        [Fact]
        public void GetGenresShouldReturnEmptyCollectionIfNoGenresAreCreated()
        {
            // Arrange
            // Act
            var allGenres = this.GenreService.GetAll();

            // Assert
            Assert.NotNull(allGenres);
            Assert.Empty(allGenres);
        }
    }
}