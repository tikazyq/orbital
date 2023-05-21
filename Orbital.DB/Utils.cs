namespace Orbital.DB;

public static class Utils
{
    public static string GetCurrentFolderPath()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        return path;
    }
    
    public static string GetDefaultDbPath()
    {
        return System.IO.Path.Join(Utils.GetCurrentFolderPath(), "orbital.db");
    }
}