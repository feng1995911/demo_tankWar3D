using System;
using System.Collections.Generic;
using GameFramework;

namespace GameMain
{
    public class CommandReceiver : ICommandReceiver
    {
        private Dictionary<CommandType, Delegate> m_Commands = new Dictionary<CommandType, Delegate>();

        public bool HasCommand(CommandType commandType)
        {
            return m_Commands.ContainsKey(commandType);
        }

        public void AddCommand<T>(CommandType commandType, CommandHandler<T> handler) where T : ICommand
        {
            if (HasCommand(commandType))
            {
                Log.Error($"Command {commandType} is exist.");
                return;
            }

            m_Commands.Add(commandType, handler);
        }

        public CommandReplyType ExecuteCommand<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                Log.Error($"Command is null.");
                return CommandReplyType.NO;
            }

            if (!HasCommand(command.CommandType))
            {
                Log.Error($"Command {command.CommandType} no exist.");
                return CommandReplyType.NO;
            }

            CommandHandler<T> commandHandler = m_Commands[command.CommandType] as CommandHandler<T>;

            if (commandHandler == null)
            {
                Log.Error($"Command {command.CommandType} no handler.");
                return CommandReplyType.NO;
            }
            return commandHandler.Invoke(command);
        }

        public void Clear()
        {
            m_Commands.Clear();
        }
    }
}
