using MediatR;

namespace datingapp1.Application.Functions.Members.Queries.GetMembersByFilter;
public class GetMembersByFilterQuery: IRequest<GetMembersByFilterQueryResponse>
{
    public string userName { get; set; }
    public int userId { get; set; }
    public int minAge { get; set; }
    public int maxAge { get; set; }
    public int gender { get; set; }
    public string orderBy { get; set; }
    public string cities { get; set; }
    public string hobbies { get; set; }
}

