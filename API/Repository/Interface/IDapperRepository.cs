using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IDapperRepository<Entity, Parameters>
        where Entity : class
        where Parameters : DynamicParameters
    {
        Entity ExecSP(string spName, Parameters parameters);
        IEnumerable<Entity> ExecSPList(string spName, Parameters parameters);
    }
}
