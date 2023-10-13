using EFGameAPI.DB.Domain;

namespace EFGameAPI.DAL
{
    public class DataAccess
    {
        private readonly DataContext _dataContext;
        public DataContext Context => _dataContext;
        public DataAccess(DataContext dataContext) { _dataContext = dataContext; }
    }
}
