using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    internal class DbService
    {
        private readonly ISqlSugarClient _client;

        public void D()
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = DbType.MySql,
                ConnectionString = "",
                IsAutoCloseConnection = true,
            });
        }
    }
}
