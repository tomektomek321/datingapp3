using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto.Hobbies;
using MediatR;

namespace datingapp1.Application.Functions.Users.Queries.MyFIlterSettings;
public class MyFilterSettingsHandler : IRequestHandler<MyFilterSettingsQuery, MyFilterSettingsResponse>
{
  private readonly IHobbyRepository _hobbyRepository;
  private readonly IHobbiesCategoryRepository _hobbiesCategoryRepository;
  private readonly IUserHobbyRepository _userHobbiesRepository;

  public MyFilterSettingsHandler(
    IHobbyRepository hobbyRepository,
    IHobbiesCategoryRepository hobbiesCategoryRepository,
    IUserHobbyRepository userHobbiesRepository
  ) {
    _hobbyRepository = hobbyRepository;
    _hobbiesCategoryRepository = hobbiesCategoryRepository;
    _userHobbiesRepository = userHobbiesRepository;
  }

  public async Task<MyFilterSettingsResponse> Handle(
    MyFilterSettingsQuery request,
    CancellationToken cancellationToken
  ) {
    var hobbies = await _hobbyRepository.GetHobbies();
    var hobbiesCategories = await _hobbiesCategoryRepository.GetHobbiesCategories();

    var userHobbies = await _userHobbiesRepository.GetUserHobbiesByUserId(request.UserId);

    var categoriesWithHobbies = new List<HobbyCategoryDto>();

    foreach (var category in hobbiesCategories)
    {
      var tempCategory = new HobbyCategoryDto();

      var tempHobbies = hobbies
          .Where(h => h.HobbiesCategory.Id == category.Id)
          .Select(h => new HobbyDto()
          {
            Id = h.Id,
            Name = h.Name,
          })
          .ToList();

      tempCategory.Id = category.Id;
      tempCategory.Name = category.Name;
      tempCategory.Hobbies = tempHobbies;

      categoriesWithHobbies.Add(tempCategory);
    }

    var response = new MyFilterSettingsResponse()
    {
      UserHobbies = userHobbies,
      CategoriesWithHobbies = categoriesWithHobbies,
    };

    return response;
  }
}
