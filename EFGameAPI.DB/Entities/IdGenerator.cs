using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DB.Entities
{
    public static class IdGenerator
    {
        private static Dictionary<Type, int> idMap = new Dictionary<Type, int>();

        public static int GetNextId<TModel>()
        {
            var entityType = typeof(TModel);
            if (!idMap.ContainsKey(entityType))
            {
                idMap[entityType] = 1;
            }
            return idMap[entityType]++;
        }
    }
}
