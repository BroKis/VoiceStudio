

using System.Linq.Expressions;

namespace VoiceSoundStudio.DAL.Repository.Interfaces;

public interface IRepository<T>:IDisposable where T:class
{
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T,bool>> criterion);
    bool Insert(T entity);       
    bool Update(T entity);
    bool Delete(int id);
    T GetID(int id);
}