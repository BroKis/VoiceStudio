using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VoiceSoundStudio.DAL.Application;
using VoiceSoundStudio.DAL.Models;
using VoiceSoundStudio.DAL.Repository.Interfaces;

namespace VoiceSoundStudio.DAL.Repository.RepositoryRealisation;

public class StatusRepository:IStatusRepository
{
    private ApplicationContext db;

    public StatusRepository()
    {
        db = new ApplicationContext();
    }

    public IEnumerable<Status> GetAll()
    {
        var list = db.Statuses.AsNoTracking();
        return list;
    }

    

    public IEnumerable<Status> Find(Expression<Func<Status,bool>> criterion)
    {
        return db.Statuses.Where(criterion).ToList();
    }

    public bool Insert(Status entity)
    {
        db.Statuses.Add(entity);
        db.SaveChanges();
        return true;
    }

    public bool Update(Status entity)
    {
        db.Entry(entity).State = EntityState.Modified;
        db.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        Status status = db.Statuses.Find(id);
        if (status != null)
            db.Statuses.Remove(status);
        db.SaveChanges();
        return true;
    }

    public Status GetID(int id)
    {
        return db.Statuses.Find(id);
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