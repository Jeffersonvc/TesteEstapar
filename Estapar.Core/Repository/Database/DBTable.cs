using System.Collections.Generic;

namespace Estapar.Core.Repository.Database
{
    public class DBTable
    {
        public string TableName { get; set; }
        public IEnumerable<DBField> Fields { get; set; }
    }
}
