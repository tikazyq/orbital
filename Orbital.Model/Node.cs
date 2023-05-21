namespace Orbital.Model;

public class Node : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public bool Enabled { get; set; } = true;

    public bool Active { get; set; } = true;
}