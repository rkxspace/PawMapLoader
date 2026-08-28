namespace PawMapLoader.Res.PawScript.EnvyRunner
{
    using System.Collections.Generic;

    public class RuntimeMemory
    {
        public int Executions;
        public Dictionary<int, object> Memory = new Dictionary<int, object>();
        public Dictionary<string, int> NamedPtr = new Dictionary<string, int>();
        public int NextMemory;
    }
}