namespace GameMain
{
    public class VirtualButton : CrossPlatformInputManager.VirtualButton
    {
        public string Name { get; }

        public VirtualButton(string name) : base(name)
        {
            Name = name;
        }
    }
}
