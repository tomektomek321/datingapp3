using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto.Hobbies;
using MediatR;

namespace datingapp1.Application.Functions.Hobbies.Commands;
public class BasicSeedHobbiesHandler : IRequestHandler<BasicSeedHobbiesCommand, BaseResponse>
{
  private readonly IHobbyRepository _hobbyRepository;
  private readonly IHobbiesCategoryRepository _hobbiesCategoryRepository;

  public BasicSeedHobbiesHandler(
    IHobbyRepository hobbyRepository,
    IHobbiesCategoryRepository hobbiesCategoryRepository
  ) {
    _hobbyRepository = hobbyRepository;
    _hobbiesCategoryRepository = hobbiesCategoryRepository;
  }
  
  public async Task<BaseResponse> Handle(
    BasicSeedHobbiesCommand request, 
    CancellationToken cancellationToken
  ) {
    var hobbies = await _hobbyRepository.GetHobbies();
    var hobbiesCategories = await _hobbiesCategoryRepository.GetHobbiesCategories();

    var categoriesWithHobbies = new List<HobbyCategoryDto>();

    foreach(var category in hobbiesCategories) {
      var tempCategory = new HobbyCategoryDto();

      var tempHobbies = hobbies
        .Where(h => h.HobbiesCategory.Id == category.Id)
        .Select(h => new HobbyDto() {
          Id = h.Id,
          Name = h.Name,
        })
        .ToList();

      tempCategory.Id = category.Id;
      tempCategory.Name = category.Name;
      tempCategory.Hobbies = tempHobbies;

      categoriesWithHobbies.Add(tempCategory);
    }

    // var respo = _hobbyRepository.BasicSeed();

    return new BaseResponse();
  }
}
