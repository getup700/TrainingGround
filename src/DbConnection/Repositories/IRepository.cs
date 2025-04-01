namespace DbConnection.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAllList();

    TEntity GetById(int id);

    void AddSave(TEntity entity);

    void UpdateSave(TEntity entity);

    void DeleteSave(TEntity entity);

    void DeleteById(int id);
}
