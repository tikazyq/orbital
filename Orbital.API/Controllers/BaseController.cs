using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orbital.DB;
using Orbital.Model;

namespace Orbital.API.Controllers;

public abstract class BaseController<T> where T : BaseModel
{
    private readonly ILogger<BaseController<T>> _logger;
    private readonly OrbitalDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    protected BaseController(ILogger<BaseController<T>> logger, OrbitalDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    [HttpGet]
    public IEnumerable<T> GetList(int page = 1, int size = 10)
    {
        return _dbSet
            .OrderByDescending(x => x.Id)
            .Skip((page - 1) * size)
            .Take(size)
            .ToList();
    }

    [HttpGet("{id}")]
    public T? Get(string id)
    {
        return _dbSet.SingleOrDefault(x => x.Id == id);
    }

    [HttpPost]
    public T Create(T model)
    {
        _dbSet.Add(model);
        _dbContext.SaveChanges();
        return model;
    }

    [HttpPut]
    public T Update(T model)
    {
        _dbSet.Update(model);
        _dbContext.SaveChanges();
        return model;
    }

    [HttpDelete("{id}")]
    public void Delete(string id)
    {
        var model = _dbSet.SingleOrDefault(x => x.Id == id);
        if (model == null)
        {
            return;
        }

        _dbSet.Remove(model);
        _dbContext.SaveChanges();
    }
}