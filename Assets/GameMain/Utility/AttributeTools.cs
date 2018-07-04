using System.Collections.Generic;
using System;
using GameFramework;

namespace GameMain
{
    public class AttributeTools
    {
        private static IAttributeStrategy _strategy;
        public static IAttributeStrategy Strategy
        {
            get
            {
                _strategy = new AttributeStrategy();
                if (_strategy == null)
                {
                    throw new Exception("Can no create Strategy instance.");
                }
                return _strategy;
            }
        }

        public static AttackResultType CalcAttackResult(IAttribute attacker, IAttribute defender)
        {
            return Strategy.CalcAttackResult(attacker, defender);
        }
        
        public static Dictionary<PropertyType, int> New()
        {
            Dictionary<PropertyType, int> propertys = new Dictionary<PropertyType, int>();
            for (int i = 1; i <= Enum.GetValues(typeof (PropertyType)).Length; i++)
            {
                PropertyType e = (PropertyType) i;
                propertys[e] = 0;
            }
            return propertys;
        }

        public static Dictionary<PropertyType, int> GetPlayerPropertys(DBPlayer player)
        {
            if (player == null)
            {
                Log.Error("Player is null");
                return null;
            }

            Dictionary<PropertyType, int> propertys = New();
            Strategy.CalcHeroLevel(propertys, player.Level);

            //TODO 计算装备和宝石
            //Strategy.CalcAllDressEquip(propertys,player.Id);
            //Strategy.CalcAllDressGem(propertys,player.Id);
            return propertys;
        }

    }
}