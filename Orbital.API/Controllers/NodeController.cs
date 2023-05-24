using Microsoft.AspNetCore.Mvc;
using Orbital.DB;
using Orbital.Model;

namespace Orbital.API.Controllers;

[ApiController]
[Route("nodes")]
public class NodeController : BaseController<Node>
{
    public NodeController(ILogger<NodeController> logger, OrbitalDbContext dbContext) : base(logger, dbContext)
    {
    }

    [HttpGet("{id}/ping")]
    public IResult RegisterNode(string id)
    {
        var existingNode = DbContext.Nodes.SingleOrDefault(n => n.Id == id);
        return existingNode == null ? Results.NotFound() : Results.Ok();
    }
}