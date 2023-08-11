using MediatR;

namespace datingapp1.Application.Functions.MySettingsAndFilters.Commands;
public class ToggleHobbyCommand: IRequest<BaseResponse>
{
    public int hobbyId { get; set; }
    public int userId { get; set; }
}
