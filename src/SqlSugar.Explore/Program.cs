using Microsoft.IdentityModel.Logging;
using SqlSugar;
using SqlSugar.Explore.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;


var db1 = new SqlSugarClient(new ConnectionConfig()
{
    DbType = DbType.MySql,
    IsAutoCloseConnection = true,
    ConnectionString = "Server=39.106.54.114;Database=sakila;Port=3306;Uid=root;Pwd=260963hzw.;"
});


//var count = 1;
//while (count <= 100)
//{
//    Console.WriteLine($"第{count}次连接");
//    count++;

//    actor1.LastName = $"{count}-{DateTime.Now.ToString()}";
//    var actors = _dbContext.Updateable<Actor>(actor1).ExecuteCommand();

//    await Task.Delay(1);
//}

var db2 = new SqlSugarClient(new ConnectionConfig()
{
    DbType = DbType.MySql,
    IsAutoCloseConnection = true,
    ConnectionString = "Server=192.168.1.221;Database=test;Port=65;Uid=root;Pwd=1q!1q!;"
});

var transOptions = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
using var scope = new TransactionScope(TransactionScopeOption.Required, transOptions);
try
{
    var time = DateTime.Now;
    var re1 = db1.Updateable<Actor>()
        .Where(x => x.Id == 1)
        .SetColumns(x => new Actor() { FirstName = $"Omar{time}" })
        .ExecuteCommand();

    throw new Exception();
    var re2 = db2.Updateable<Student>()
        .Where(x => x.Id == 111)
        .SetColumns(x => new Student() { Name = $"Omar{time}" })
        .ExecuteCommand();
    scope.Complete();
}
catch (Exception e)
{
    Console.WriteLine(e);
}
