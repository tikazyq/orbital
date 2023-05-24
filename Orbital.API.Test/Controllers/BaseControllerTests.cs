using Microsoft.Extensions.Logging;
using Moq;
using Orbital.API.Controllers;
using Orbital.DB;
using Orbital.Model;

namespace Orbital.API.Test.Controllers;

public class BaseControllerTests
{
    private ILogger<NodeController> logger;
    private NodeController controller;

    [SetUp]
    public void Setup()
    {
        logger = new Mock<ILogger<NodeController>>().Object;
        var factory = new OrbitalDbContextFactory();
        var dbContext = factory.CreateDbContext(Array.Empty<string>());
        controller = new NodeController(logger, dbContext);
    }

    [Test, Order(1)]
    public void Create()
    {
        var result = controller.Create(new Node());

        Assert.That(result, Is.Not.Null);
    }

    [Test, Order(2)]
    public void GetList()
    {
        var result = controller.GetList();
        var enumerable = result as Node[] ?? result.ToArray();

        Assert.That(enumerable, Is.Not.Null);
        Assert.That(enumerable, Is.InstanceOf<Node[]>());
        Assert.That(enumerable, Is.Not.Empty);
    }

    [Test, Order(2)]
    public void Get()
    {
        var result = controller.GetList();
        var enumerable = result as Node[] ?? result.ToArray();
        var node = enumerable.First();

        var res = controller.Get(node.Id);

        Assert.That(res, Is.EqualTo(node));
    }

    [Test, Order(3)]
    public void Update()
    {
        var result = controller.GetList();
        var enumerable = result as Node[] ?? result.ToArray();
        var node = enumerable.First();

        node.Enabled = !node.Enabled;
        var res = controller.Update(node);

        Assert.That(res, Is.EqualTo(node));
    }

    [Test, Order(4)]
    public void Delete()
    {
        var result = controller.GetList();
        var enumerable = result as Node[] ?? result.ToArray();

        foreach (var node in enumerable)
        {
            controller.Delete(node.Id);
        }

        result = controller.GetList();
        enumerable = result as Node[] ?? result.ToArray();

        Assert.That(enumerable, Is.Empty);
    }
}