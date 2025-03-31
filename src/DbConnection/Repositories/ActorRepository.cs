using DbConnection.Entities;
using SqlSugar;

namespace DbConnection.Repositories;

public class ActorRepository : IRepository<Actor>
{
    private SqlSugarClient _dbContext;


    public ActorRepository(SqlSugarClient sqlSugarScope)
    {
        _dbContext = sqlSugarScope;
    }

    public void AddSave(Actor entity)
    {
        _dbContext.Insertable(entity).ExecuteCommand();
    }

    public void DeleteById(int id)
    {
        _dbContext.DeleteableByObject(id).ExecuteCommand();
    }

    public void DeleteSave(Actor entity)
    {
        _dbContext.Deleteable(entity).ExecuteCommand();
    }

    public IEnumerable<Actor> GetAllList()
    {
        return _dbContext.Queryable<Actor>().ToList();
    }

    public Actor GetById(int id)
    {
        return _dbContext.Queryable<Actor>().InSingle(id);
    }

    public void UpdateSave(Actor entity)
    {
        _dbContext.Updateable(entity);
    }
}
