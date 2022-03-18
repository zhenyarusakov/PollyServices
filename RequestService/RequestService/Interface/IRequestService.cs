namespace RequestService.Interface;

public interface IRequestService
{
    Task<string> MakeRequest();
}