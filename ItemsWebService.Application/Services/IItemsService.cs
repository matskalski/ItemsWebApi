namespace ItemsWebService.Application.Services
{
    public interface IItemsService
    {
        Task<bool> ExistisByCode(string name);
    }
}
