using GameFramework;

namespace GameMain
{
    public class BuffData
    {
        public BuffData(int id)
        {
            var dtBuff = GameEntry.DataTable.GetDataTable<DRBuff>();
            DRBuff drBuff = dtBuff.GetDataRow(id);
            if (drBuff == null)
            {
                Log.Error("Can no get DRBuff by id:{0}", id);
                return;
            }

            Name = drBuff.Name;
            Icon = drBuff.Icon;
            BuffType = (BuffType) drBuff.BuffType;
            LifeTime = drBuff.LifeTime;
            OverlayType = (BuffOverlayType) drBuff.OverlayType;
            MaxOverlayNum = drBuff.MaxOverlayNum;
            DestroyType = (BuffDestroyType) drBuff.DestroyType;
            Result = drBuff.Result;
            ResultAttrID = drBuff.ResultAttrID;
            ResultInterval = drBuff.ResultInterval;
            EffectID = drBuff.EffectID;
            EffectBind = drBuff.EffectBind;
            ChangeModelID = drBuff.ChangeModelID;
            ChangeModelScale = drBuff.ChangeModelScale;
            Desc = drBuff.Desc;
        }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 图标
        /// </summary>
        public int Icon { get; private set; }

        /// <summary>
        /// Buff类型
        /// </summary>
        public BuffType BuffType { get; private set; }

        /// <summary>
        /// 持续时间
        /// </summary>
        public int LifeTime { get; private set; }

        /// <summary>
        /// 叠加类型
        /// </summary>
        public BuffOverlayType OverlayType { get; private set; }

        /// <summary>
        /// 最大叠加数量
        /// </summary>
        public int MaxOverlayNum { get; private set; }

        /// <summary>
        /// 销毁类型
        /// </summary>
        public BuffDestroyType DestroyType { get; private set; }

        /// <summary>
        /// 作用类型
        /// </summary>
        public int Result { get; private set; }

        /// <summary>
        /// 作用属性
        /// </summary>
        public int ResultAttrID { get; private set; }

        /// <summary>
        /// 作用间隔
        /// </summary>
        public int ResultInterval { get; private set; }

        /// <summary>
        /// 特效编号
        /// </summary>
        public int EffectID { get; private set; }

        /// <summary>
        /// 特效绑定位置
        /// </summary>
        public int EffectBind { get; private set; }

        /// <summary>
        /// 更改模型的编号
        /// </summary>
        public int ChangeModelID { get; private set; }

        /// <summary>
        /// 变换模型大小
        /// </summary>
        public int ChangeModelScale { get; private set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Desc { get; private set; }


    }
}
