using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VoiceSoundStudio.DAL.Application;
using VoiceSoundStudio.DAL.Models;
using VoiceSoundStudio.DAL.Repository.Interfaces;

namespace VoiceSoundStudio.DAL.Repository.RepositoryRealisation;

public class OrderToVoicicngRepository:IOrderToVoicicngRepository
{
    private  ApplicationContext db;
    public OrderToVoicicngRepository()
    {
        db = new ApplicationContext();
    }
    
    
    public IEnumerable<OrderToVoicing> GetAll()
    {
        return db.OrderVoicings.Include(x => x.Actors).AsNoTracking();
    }

   

    public IEnumerable<OrderToVoicing> Find(Expression<Func<OrderToVoicing,bool>> criterion)
    {
        return db.OrderVoicings.
            Include(x => x.Actors)
            .Where(criterion).ToList();
    }


    public  bool Insert(OrderToVoicing entity)
    {
        db.OrderVoicings.Add(entity);
        db.SaveChanges();
        return true;

    }

    public bool Update(OrderToVoicing entity)
    {

        var obj = db.OrderVoicings.Include(x => x.Actors).FirstOrDefault(x => x.Id == entity.Id);
        if (obj is not null)
        {
             obj.StatusId = entity.StatusId;
            if (obj.Actors.Count == 0)
            {
                obj.Actors = entity.Actors;
            }
        }
        db.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        OrderToVoicing orderToVoicing = db.OrderVoicings.Include(x => x.Actors).FirstOrDefault(x => x.Id == id);
        if (orderToVoicing != null)
            db.OrderVoicings.Remove(orderToVoicing);
        db.SaveChanges();
        return true;

    }

    public OrderToVoicing GetID(int id)
    {
        return db.OrderVoicings.
            Include(x => x.Actors).FirstOrDefault(x => x.Id==id);
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