
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DRHeroLevel : IDataRow
	{
		/// <summary>
		/// 编号
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 需求经验
		/// </summary>
		public int RequireExp { get; private set; }

		/// <summary>
		/// 生命值
		/// </summary>
		public int LHP { get; private set; }

		/// <summary>
		/// 攻击力
		/// </summary>
		public int ATK { get; private set; }

		/// <summary>
		/// 防御力
		/// </summary>
		public int DEF { get; private set; }

		/// <summary>
		/// 爆击
		/// </summary>
		public int CRI { get; private set; }

		/// <summary>
		/// 爆伤
		/// </summary>
		public int BUR { get; private set; }

		/// <summary>
		/// 魔法值
		/// </summary>
		public int LMP { get; private set; }

		/// <summary>
		/// 吸血
		/// </summary>
		public int VAM { get; private set; }

		/// <summary>
		/// 命中
		/// </summary>
		public int HIT { get; private set; }

		/// <summary>
		/// 闪避
		/// </summary>
		public int DOG { get; private set; }

		/// <summary>
		/// 爆防
		/// </summary>
		public int BAF { get; private set; }

		/// <summary>
		/// 下一等级
		/// </summary>
		public int NextLevel { get; private set; }


		public DRHeroLevel()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			RequireExp = int.Parse(text[++index]);
			LHP = int.Parse(text[++index]);
			ATK = int.Parse(text[++index]);
			DEF = int.Parse(text[++index]);
			CRI = int.Parse(text[++index]);
			BUR = int.Parse(text[++index]);
			LMP = int.Parse(text[++index]);
			VAM = int.Parse(text[++index]);
			HIT = int.Parse(text[++index]);
			DOG = int.Parse(text[++index]);
			BAF = int.Parse(text[++index]);
			NextLevel = int.Parse(text[++index]);
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

