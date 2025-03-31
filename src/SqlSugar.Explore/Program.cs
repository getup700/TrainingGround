using SqlSugar;
using SqlSugar.Explore.Entities;


 SqlSugarScope _dbContext = new SqlSugarScope(new ConnectionConfig()
{
    DbType = DbType.MySql,
    IsAutoCloseConnection = true,
    ConnectionString = "Server=39.106.54.114;Database=sakila;Port=3306;Uid=root;Pwd=260963hzw.;"
});
var actor1 = _dbContext.Queryable<Actor>().First();

var count = 1;
while (count <= 100)
{
    Console.WriteLine($"第{count}次连接");
    count++;

    actor1.LastName = $"{count}-{DateTime.Now.ToString()}";
    var actors = _dbContext.Updateable<Actor>(actor1).ExecuteCommand();

    await Task.Delay(1);
}
