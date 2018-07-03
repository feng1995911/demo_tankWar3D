using UnityEngine;

namespace GameMain
{
    public static partial class Constant
    {
        /// <summary>
        /// 层。
        /// </summary>
        public static class Layer
        {
            public const string DefaultLayerName = "Default";
            public static readonly int DefaultLayerId = LayerMask.NameToLayer(DefaultLayerName);

            public const string UILayerName = "UI";
            public static readonly int UILayerId = LayerMask.NameToLayer(UILayerName);

            public const string Player = "Player";
            public static readonly int PlayerId = LayerMask.NameToLayer(Player);

            public const string Monster = "Monster";
            public static readonly int MonsterId = LayerMask.NameToLayer(Monster);

            public const string Npc = "Npc";
            public static readonly int NpcId = LayerMask.NameToLayer(Npc);

            public const string Barrer = "Barrer";
            public static readonly int BarrerId = LayerMask.NameToLayer(Barrer);

            public const string Partner = "Partner";
            public static readonly int PartnerId = LayerMask.NameToLayer(Partner);

            public const string Pet = "Pet";
            public static readonly int PetId = LayerMask.NameToLayer(Pet);

            public const string Mount = "Mount";
            public static readonly int MountId = LayerMask.NameToLayer(Mount);

            public const string TouchEffect = "TouchEffect";
            public static readonly int TouchEffectId = LayerMask.NameToLayer(TouchEffect);
        }
    }
}
