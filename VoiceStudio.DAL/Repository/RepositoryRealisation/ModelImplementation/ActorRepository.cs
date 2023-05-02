using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VoiceSoundStudio.DAL.Application;
using VoiceSoundStudio.DAL.Models;
using VoiceSoundStudio.DAL.Repository.Interfaces;

namespace VoiceSoundStudio.DAL.Repository.RepositoryRealisation;

public class ActorRepository:IActorRepository
{
    private ApplicationContext db;

    public ActorRepository()
    {
        db = new ApplicationContext();
    }
    
    public IEnumerable<Actor> GetAll()
    {
        var list = db.Actors.AsNoTracking().ToList();
        return list;
    }
    
   

    public IEnumerable<Actor> Find(Expression<Func<Actor,bool>> criterion)
    {
        return db.Actors.Where(criterion).ToList();
    }


    public bool Insert(Actor entity)
    {
        db.Actors.Add(entity);
        db.SaveChanges();
        return true;
    }

    public bool Update(Actor entity)
    {
        Actor actor = db.Actors.Find(entity.Id);
        if (actor != null)
        {
            actor.Fio = entity.Fio;
            actor.BirthDate = entity.BirthDate;
            actor.Biography = entity.Biography;
            actor.Voice = entity.Voice;
            actor.ImagePath = entity.ImagePath;
            actor.StudioId = entity.StudioId;
            actor.ActorStatusId = entity.ActorStatusId;
        }
        db.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        Actor actor =  db.Actors.Find(id);
        if (actor != null)
            db.Actors.Remove(actor);
        db.SaveChanges();
        return true;

    }

    public Actor GetID(int id)
    {
        return db.Actors.Find(id);
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