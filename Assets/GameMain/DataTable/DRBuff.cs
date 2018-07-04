
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DRBuff : IDataRow
	{
		/// <summary>
		/// 编号
		/// </summary>
		public int Id { get; private set; }

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
		public int BuffType { get; private set; }

		/// <summary>
		/// 持续时间
		/// </summary>
		public int LifeTime { get; private set; }

		/// <summary>
		/// 叠加类型
		/// </summary>
		public int OverlayType { get; private set; }

		/// <summary>
		/// 最大叠加数量
		/// </summary>
		public int MaxOverlayNum { get; private set; }

		/// <summary>
		/// 销毁类型
		/// </summary>
		public int DestroyType { get; private set; }

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


		public DRBuff()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			Name = text[++index];
			Icon = int.Parse(text[++index]);
			BuffType = int.Parse(text[++index]);
			LifeTime = int.Parse(text[++index]);
			OverlayType = int.Parse(text[++index]);
			MaxOverlayNum = int.Parse(text[++index]);
			DestroyType = int.Parse(text[++index]);
			Result = int.Parse(text[++index]);
			ResultAttrID = int.Parse(text[++index]);
			ResultInterval = int.Parse(text[++index]);
			EffectID = int.Parse(text[++index]);
			EffectBind = int.Parse(text[++index]);
			ChangeModelID = int.Parse(text[++index]);
			ChangeModelScale = int.Parse(text[++index]);
			Desc = text[++index];
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

