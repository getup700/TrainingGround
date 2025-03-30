using SqlSugar;
using SqlSugar.Explore.Entities;


var db = new SqlSugarClient(new ConnectionConfig()
{
    DbType = DbType.MySql,
    IsAutoCloseConnection = true,
    ConnectionString = "Server=39.106.54.114;Database=sakila;Port=3306;Uid=root;Pwd=260963hzw.;"
}, x =>
{
    x.Aop.OnLogExecuting = (sql, pars) =>
    {
        Console.WriteLine(sql + "\r\n" +
            x.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
        Console.WriteLine();
    };
});

var actors = db.Queryable<Actor>().ToList();
actors.ForEach(x => Console.WriteLine(x.FirstName));