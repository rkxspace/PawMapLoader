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
            SessionCreateInfo sesinfo = new SessionCreateInfo { SystemId = sysid, Next = null };
            Session xrsession;
            XRrt.CreateSession(inst, &sesinfo, &xrsession);
            
            Space appspace;
            ReferenceSpaceCreateInfo spcinfo = new ReferenceSpaceCreateInfo()
            {
                ReferenceSpaceType = ReferenceSpaceType.Local,
                PoseInReferenceSpace = new Posef()
                {
                    Orientation = new Quaternionf() { W = 1f },
                    Position = new Vector3f()
                }
            };
            XRrt.CreateReferenceSpace(xrsession, &spcinfo, &appspace);

            SessionBeginInfo beginInfo = new SessionBeginInfo()
            {
                PrimaryViewConfigurationType = ViewConfigurationType.PrimaryStereo
            };
            XRrt.BeginSession(xrsession, &beginInfo);
        }
    }
}