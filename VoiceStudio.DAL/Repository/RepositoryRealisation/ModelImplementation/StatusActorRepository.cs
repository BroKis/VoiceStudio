using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VoiceSoundStudio.DAL.Application;
using VoiceSoundStudio.DAL.Models;
using VoiceSoundStudio.DAL.Repository.Interfaces;

namespace VoiceSoundStudio.DAL.Repository.RepositoryRealisation;

public class ActorStatusRepository:IActorStatusRepository
{
    private ApplicationContext db;

    public ActorStatusRepository()
    {
        db = new ApplicationContext();
    }
  
    public IEnumerable<ActorStatus> GetAll()
    {
        var list = db.ActorStatuses.AsNoTracking();
        return list;
    }

    public IEnumerable<ActorStatus> Find(Expression<Func<ActorStatus,bool>> criterion)
    {
        return db.ActorStatuses.Where(criterion).ToList();
    }

    public bool Insert(ActorStatus entity)
    {
        db.ActorStatuses.Add(entity);
        db.SaveChanges();
        return true;
    }

    public bool Update(ActorStatus entity)
    {
        db.Entry(entity).State = EntityState.Modified;
        db.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        ActorStatus status = db.ActorStatuses.Find(id);
        if (status != null)
            db.ActorStatuses.Remove(status);
        db.SaveChanges();
        return true;
    }

    public ActorStatus GetID(int id)
    {
        return db.ActorStatuses.Find(id);
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