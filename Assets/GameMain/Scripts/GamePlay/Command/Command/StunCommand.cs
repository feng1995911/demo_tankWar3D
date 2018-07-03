namespace GameMain
{
    public class StunCommand:ICommand
    {
        public CommandType CommandType { get; }

        public float LastTime;

        public StunCommand(float lastTime)
        {
            this.LastTime = lastTime;
            this.CommandType = CommandType.Stun;
        }
    }
}
