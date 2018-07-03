using System;

namespace GameMain
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field)]
    public class LevelVariable : Attribute
    {
        public enum ModeType
        {
            None,
            Unity,
            Collection,
            Custom
        }

        public string Label = string.Empty;

        public ModeType Mode = ModeType.None;

        public Type MapVariableType { get; set; }

        public Type KeyType { get; set; }

        public Type ValueType { get; set; }
    }
}
