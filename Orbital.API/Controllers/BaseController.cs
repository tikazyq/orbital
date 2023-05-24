using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orbital.DB;
using Orbital.Model;

namespace Orbital.API.Controllers;

public abstract class BaseController<T> where T : BaseModel
{
    protected readonly ILogger<BaseController<T>> Logger;
    protected readonly OrbitalDbContext DbContext;
    protected readonly DbSet<T> DbSet;

    protected BaseController(ILogger<BaseController<T>> logger, OrbitalDbContext dbContext)
    {
        Logger = logger;
        DbContext = dbContext;
        DbSet = DbContext.Set<T>();
    }

    [HttpGet]
    public IEnumerable<T> GetList(int page = 1, int size = 10)
    {
        return DbSet
            .OrderByDescending(x => x.Id)
            .Skip((page - 1) * size)
            .Take(size)
            .ToList();
    }

    [HttpGet("{id}")]
    public T? Get(string id)
    {
        return DbSet.SingleOrDefault(x => x.Id == id);
    }

    [HttpPost]
    public T Create(T model)
    {
        DbSet.Add(model);
        DbContext.SaveChanges();
        return model;
    }

    [HttpPut]
    public T Update(T model)
    {
        var existingResult = DbSet.SingleOrDefault(x => x.Id == model.Id);
        if (existingResult == null)
        {
            throw new Exception("Not found");
        }

        DbSet.Update(model);
        DbContext.SaveChanges();
        return model;
    }

    [HttpDelete("{id}")]
    public void Delete(string id)
    {
        var existingResult = DbSet.SingleOrDefault(x => x.Id == id);
        if (existingResult == null)
        {
            throw new Exception("Not found");
        }

        DbSet.Remove(existingResult);
        DbContext.SaveChanges();
    }
}