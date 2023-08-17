using MediatR;

namespace datingapp1.Application.Functions.MySettingsAndFilters.Commands;
public class ToggleHobbyCommand: IRequest<BaseResponse>
{
    public int UserId { get; set; }
    public int HobbyId { get; set; }
}
