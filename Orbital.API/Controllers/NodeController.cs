using Microsoft.AspNetCore.Mvc;
using Orbital.DB;
using Orbital.Model;

namespace Orbital.API.Controllers;

[ApiController]
[Route("nodes")]
public class NodeController : BaseController<Node>
{
    public NodeController(ILogger<BaseController<Node>> logger, OrbitalDbContext dbContext) : base(logger, dbContext)
    {
    }
}