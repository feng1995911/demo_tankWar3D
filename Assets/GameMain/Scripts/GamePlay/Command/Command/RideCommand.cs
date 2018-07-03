using UnityEngine;

namespace GameMain
{
    public class RideCommand : ICommand
    {
        public RideCommand()
        {
            CommandType = CommandType.Ride;
        }

        public CommandType CommandType { get; }
    }
}
