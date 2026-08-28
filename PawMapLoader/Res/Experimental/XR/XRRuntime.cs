namespace PawMapLoader.Res.Experimental.XR
{
    //TODO
    using Silk.NET.OpenXR;

    public unsafe class XRRuntime
    {
        public delegate bool Update();

        public XR XRrt;
        public Update xrUpdate;

        public XRRuntime()
        {
            XRrt = XR.GetApi();
            Instance inst;
            InstanceCreateInfo xrInstInfo = new InstanceCreateInfo();
            XRrt.CreateInstance(&xrInstInfo, &inst);
            SystemGetInfo sysinf = new SystemGetInfo { FormFactor = FormFactor.HeadMountedDisplay };
            ulong sysid;
            XRrt.GetSystem(inst, &sysinf, &sysid);
        }
    }
}