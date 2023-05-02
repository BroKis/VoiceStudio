using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VoiceSoundStudio.DAL.Application;
using VoiceSoundStudio.DAL.Models;
using VoiceSoundStudio.DAL.Repository.Interfaces;

namespace VoiceSoundStudio.DAL.Repository.RepositoryRealisation;

public class TypesRepository:ITypesRepository
{
    private ApplicationContext db;

    public TypesRepository()
    {
        db = new ApplicationContext();
    }
    public IEnumerable<Types> GetAll()
    {
        return db.Types.AsNoTracking();
    }

   

    public IEnumerable<Types> Find(Expression<Func<Types,bool>> criterion)
    {
        return db.Types.Where(criterion).ToList();
    }

    public bool Insert(Types entity)
    {
        db.Types.Add(entity);
        db.SaveChanges();
        return true;
    }

    public bool Update(Types entity)
    {
        db.Entry(entity).State = EntityState.Modified;
        db.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        Types type = db.Types.Find(id);
        if (type != null)
            db.Types.Remove(type);
        db.SaveChanges();
        return true;
    }

    public Types GetID(int id)
    {
        return db.Types.Find(id);
    }

    private bool disposed = false;
 
    public virtual void Dispose(bool disposing)
    {
        if(!this.disposed)
        {
            if(disposing)
            {
                db.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}