using Estapar.Core.Repository.Database;
using System.Data.Common;
using System.Data.SqlClient;

namespace Estapar.Core.Repository.Helper
{
    public class ConnectionHelper
    {
        private DBInstance _dBInstance;
        private readonly string _connectionString;
        public ConnectionHelper(DBInstance dbInstance, string connectionString)
        {
            this._dBInstance = dbInstance;
            _connectionString = connectionString;
        }

        private DbConnection _connection;

        public DbConnection GetConnection()
        {
            if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
            {
                switch (this._dBInstance)
                {
                    case DBInstance.SQLServer:
                        _connection = new SqlConnection(_connectionString);
                        break;
                }

                _connection.Open();
            }
            return _connection;
        }

        public void Dispose()
        {
            _connection.Dispose();
            _connection = null;
        }
    }
}
