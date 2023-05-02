using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using VoiceSoundStudio.DAL.Application;
using VoiceSoundStudio.DAL.Models;
using VoiceSoundStudio.DAL.Repository.Interfaces;

namespace VoiceSoundStudio.DAL.Repository.RepositoryRealisation;

public class StudioRepository:IStudioRepository
{
    private ApplicationContext db;
    public StudioRepository()
    {
        db = new ApplicationContext();
    }
    public IEnumerable<Studio> GetAll()
    {
        var list = db.Studios.ToList();
        return list;
    }
    

    

    public IEnumerable<Studio> Find(Expression<Func<Studio,bool>> criterion)
    {
        return db.Studios.Where(criterion).ToList();
    }

    public bool Insert(Studio entity)
    {
        db.Studios.Add(entity);
        db.SaveChanges();
        return true;
    }

    public bool Update(Studio entity)
    {

        Studio studio = db.Studios.Find(entity.Id);
        if (studio != null)
        {
            studio.Title = entity.Title;
            studio.Description = entity.Description;
            studio.ImagePath = entity.ImagePath;
        }
        db.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        Studio studio = db.Studios.Find(id);
        if (studio != null)
            db.Studios.Remove(studio); 
        db.SaveChanges();
        return true;
    }

    public Studio GetID(int id)
    {
        return db.Studios.Find(id);
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