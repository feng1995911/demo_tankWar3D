namespace GameMain
{
    public class VirtualAxisBase : CrossPlatformInputManager.VirtualAxis
    {
        public string Name { get; }

        public VirtualAxisBase(string name) : base(name)
        {
            Name = name;
        }

    }
}
