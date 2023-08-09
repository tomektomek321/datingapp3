using MediatR;

namespace datingapp1.Application.Functions.Users.Queries.MyFIlterSettings
{
    public class MyFilterSettingsQuery: IRequest<MyFilterSettingsResponse>
    {
        public int UserId { get; set; }
    }
}