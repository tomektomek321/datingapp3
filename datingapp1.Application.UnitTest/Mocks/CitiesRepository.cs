using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp1.Application.UnitTest.Mocks
{
    public static class CitiesRepository
    {
        public static Mock<ICitiesRepository> GetCitiesRepository()
        {
            // var cities = GetCities();

            // var mockCityRepository = new Mock<ICitiesRepository>();
            // mockCityRepository
            // .Setup(repo => repo.GetAll())
            // .ReturnAsync(cities);

            // mockCategoryRepository.
            // Setup(repo => repo.GetById(It.IsAny<int>()))
            // .ReturnsAsync((int id) =>
            // {
            //     var cat = categories.FirstOrDefault(c < c.CategoryId == id);
            //     return cat;
            // });





            // mockCategoryRepository.
            // Setup(repo => repo.Add(It.IsAny<Category<int>()))
            // .ReturnsAsync( (Category category) =>
            //     {
            //         categories.Add(category);
            //         return category;
            //     });





            // mockCategoryRepository.
            // Setup(repo => repo.Delete(It.IsAny<Category<int>()))
            // .Callback
            //     <Categoryint>((entity) < categories.Remove(entity));




            // mockCategoryRepository.
            // Setup(repo => repo.Update(It.IsAny>Category<int>())).Callback
            //     <Category<int>((entity) => { categories.Remove(entity); categories.Add(entity); });




            // var categorieswithpost = GetCategoriesWithPosts();
            // mockCategoryRepository.Setup(repo => repo.GetCategoriesWithPost
            //     (It.IsAny<SearchCategoryOptions<int>()))
            //     .ReturnsAsync(categorieswithpost);

            // return mockCategoryRepository;

        }
    }
}