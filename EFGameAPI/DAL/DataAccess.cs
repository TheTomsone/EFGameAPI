using EFGameAPI.DB.Domain;

namespace EFGameAPI.DAL
{
    public class DataAccess : IDataAccess
    {
        private readonly DataContext _dataContext;
        public DataContext DataContext => _dataContext;
        public DataAccess(DataContext dataContext) { _dataContext = dataContext; }
    }
}
