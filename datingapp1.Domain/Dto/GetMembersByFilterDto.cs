namespace datingapp1.Domain.Dto
{
    public class GetMembersByFilterDto
    {
        public int minAge { get; set; }
        public int maxAge { get; set; }
        public int gender { get; set; }
        public string orderBy { get; set; }
        public string cities { get; set; }
        public string hobbies { get; set; }
    }
}