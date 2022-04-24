namespace datingapp1.Application
{
    public enum ResponseStatus
    {
        Success = 0,
        NotFound = 1,
        BadQueryRequest = 2,
        ValidationError = 3,
        Exception = 4,
        DataBaseError = 5,
        OtherClientApiError = 5,
    }
}