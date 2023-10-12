using EFGameAPI.DB.Domain;

namespace EFGameAPI.DAL
{
    public interface IDataAccess
    {
        DataContext DataContext { get; }
    }
}
