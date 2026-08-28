namespace PawMapLoader.Res.PawScript.EnvyRunner
{
    public class ScriptRunner
    {
        private class EnvyUpdates
        {
            public delegate void FrameUpdate();

            public FrameUpdate Update = () => { };
        }
    }
}