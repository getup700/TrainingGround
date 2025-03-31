using DbConnection.Entities;
using SqlSugar;

namespace DbConnection.Repositories;

internal class ActorUnitOfWork : IDisposable
{
    private SqlSugarClient _dbContext;
    private bool disposedValue = false;

    /// <summary>
    /// 数据库上下文实例化是在工作单元中是实现的
    /// </summary>
    public ActorUnitOfWork()
    {
        _dbContext = new SqlSugarClient(new ConnectionConfig()
        {
            DbType = DbType.MySql,
            IsAutoCloseConnection = true,
            ConnectionString = "Server=39.106.54.114;Database=sakila;Port=3306;Uid=root;Pwd=260963hzw.;"
        });
    }

    private IRepository<Actor> _actorRepository;

    public IRepository<Actor> ActorRepository => _actorRepository ??= new ActorRepository(_dbContext);

    public void SaveChanges()
    {
        _dbContext.Ado.CommitTran();
    }


    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
