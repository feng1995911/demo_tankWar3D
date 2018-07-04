
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DRLevel : IDataRow
	{
		/// <summary>
		/// 编号
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 场景
		/// </summary>
		public int Scene { get; private set; }

		/// <summary>
		/// 名字
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// 关卡类型
		/// </summary>
		public int LevelType { get; private set; }

		/// <summary>
		/// 需求等级
		/// </summary>
		public int LevelRequest { get; private set; }

		/// <summary>
		/// 图标
		/// </summary>
		public int Icon { get; private set; }

		/// <summary>
		/// 背景图片
		/// </summary>
		public int Background { get; private set; }

		/// <summary>
		/// 花费编号
		/// </summary>
		public int CostActionId { get; private set; }

		/// <summary>
		/// 花费数量
		/// </summary>
		public int CostActionNum { get; private set; }

		/// <summary>
		/// 宝石奖励编号
		/// </summary>
		public int GetMoneyId { get; private set; }

		/// <summary>
		/// 金钱奖励
		/// </summary>
		public int GetMoneyRatio { get; private set; }

		/// <summary>
		/// 经验奖励
		/// </summary>
		public int GetExpRatio { get; private set; }

		/// <summary>
		/// 第一物品奖励
		/// </summary>
		public int FirstAwardId { get; private set; }

		/// <summary>
		/// 物品奖励
		/// </summary>
		public int AwardId { get; private set; }

		/// <summary>
		/// 下拉物品奖励
		/// </summary>
		public int DropBoxAwardId { get; private set; }

		/// <summary>
		/// 场景编号
		/// </summary>
		public int SceneId { get; private set; }

		/// <summary>
		/// 战斗时间
		/// </summary>
		public int BattleTimes { get; private set; }

		/// <summary>
		/// 解锁等级
		/// </summary>
		public int UnlockLevel { get; private set; }

		/// <summary>
		/// 战斗输出
		/// </summary>
		public int FightValue { get; private set; }

		/// <summary>
		/// 星级1条件
		/// </summary>
		public int StarCondition1 { get; private set; }

		/// <summary>
		/// 星级1
		/// </summary>
		public int StarValue1 { get; private set; }

		/// <summary>
		/// 星级2条件
		/// </summary>
		public int StarCondition2 { get; private set; }

		/// <summary>
		/// 星级2
		/// </summary>
		public int StarValue2 { get; private set; }

		/// <summary>
		/// 星级3条件
		/// </summary>
		public int StarCondition3 { get; private set; }

		/// <summary>
		/// 星级3
		/// </summary>
		public int StarValue3 { get; private set; }

		/// <summary>
		/// 描述
		/// </summary>
		public string Desc { get; private set; }


		public DRLevel()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			Scene = int.Parse(text[++index]);
			Name = text[++index];
			LevelType = int.Parse(text[++index]);
			LevelRequest = int.Parse(text[++index]);
			Icon = int.Parse(text[++index]);
			Background = int.Parse(text[++index]);
			CostActionId = int.Parse(text[++index]);
			CostActionNum = int.Parse(text[++index]);
			GetMoneyId = int.Parse(text[++index]);
			GetMoneyRatio = int.Parse(text[++index]);
			GetExpRatio = int.Parse(text[++index]);
			FirstAwardId = int.Parse(text[++index]);
			AwardId = int.Parse(text[++index]);
			DropBoxAwardId = int.Parse(text[++index]);
			SceneId = int.Parse(text[++index]);
			BattleTimes = int.Parse(text[++index]);
			UnlockLevel = int.Parse(text[++index]);
			FightValue = int.Parse(text[++index]);
			StarCondition1 = int.Parse(text[++index]);
			StarValue1 = int.Parse(text[++index]);
			StarCondition2 = int.Parse(text[++index]);
			StarValue2 = int.Parse(text[++index]);
			StarCondition3 = int.Parse(text[++index]);
			StarValue3 = int.Parse(text[++index]);
			Desc = text[++index];
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

