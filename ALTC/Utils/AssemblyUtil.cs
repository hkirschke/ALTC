using System.Reflection;

namespace ALTC.Utils;

public static class AssemblyUtil
{
    public static IEnumerable<Assembly> GetAssemblies()
    {
        return new Assembly[]
        {
            Assembly.Load("ALTC.Application"),
            Assembly.Load("ALTC.Infra.Db.Memory.Cache"),
            Assembly.Load("ALTC.Infra.JsonPlaceHolder.API"),
        };
    }
}