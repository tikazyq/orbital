using Microsoft.Extensions.Logging;

namespace Orbital.API;

public class Agent
{
    public string CurrentState;

    private IEnumerable<Worker> _workers = Array.Empty<Worker>();

    public Agent()
    {
        CurrentState = "Idle";
    }

    public void Start()
    {
    }
}