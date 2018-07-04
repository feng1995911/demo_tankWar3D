
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DRActorEntity : IDataRow
	{
		/// <summary>
		/// 编号
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 所属实体组
		/// </summary>
		public string Group { get; private set; }

		/// <summary>
		/// 名字
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// 称号
		/// </summary>
		public string Title { get; private set; }

		/// <summary>
		/// 图标
		/// </summary>
		public int Icon { get; private set; }

		/// <summary>
		/// 描述
		/// </summary>
		public string Desc { get; private set; }

		/// <summary>
		/// 等级
		/// </summary>
		public int Level { get; private set; }

		/// <summary>
		/// 角色类型
		/// </summary>
		public int ActorType { get; private set; }

		/// <summary>
		/// 种族
		/// </summary>
		public int Race { get; private set; }

		/// <summary>
		/// 性别
		/// </summary>
		public int Sex { get; private set; }

		/// <summary>
		/// 怪物类型
		/// </summary>
		public int MonsterType { get; private set; }

		/// <summary>
		/// 品质
		/// </summary>
		public int Quality { get; private set; }

		/// <summary>
		/// 向前速度
		/// </summary>
		public float Speed { get; private set; }

		/// <summary>
		/// 向后速度
		/// </summary>
		public float BSpeed { get; private set; }

		/// <summary>
		/// 出生特效
		/// </summary>
		public int BornEffect { get; private set; }

		/// <summary>
		/// 死亡特效
		/// </summary>
		public int DeadEffect { get; private set; }

		/// <summary>
		/// 在UI的位置
		/// </summary>
		public Vector3 StagePos { get; private set; }

		/// <summary>
		/// 在UI的大小
		/// </summary>
		public int StageScale { get; private set; }

		/// <summary>
		/// AI状态初始化
		/// </summary>
		public string AIFeature { get; private set; }

		/// <summary>
		/// 击杀经验
		/// </summary>
		public int KillExp { get; private set; }

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
		/// 语音资源
		/// </summary>
		public string VoiceAsset { get; private set; }

		/// <summary>
		/// 模型资源
		/// </summary>
		public string ModelAsset { get; private set; }

		/// <summary>
		/// Ai攻击距离
		/// </summary>
		public float AiAtkDist { get; private set; }

		/// <summary>
		/// Ai跟随距离
		/// </summary>
		public float AiFollowDist { get; private set; }

		/// <summary>
		/// Ai警示距离
		/// </summary>
		public float AiWaringDist { get; private set; }

		/// <summary>
		/// Ai寻敌间隔
		/// </summary>
		public float FindEnemyInterval { get; private set; }

		/// <summary>
		/// AI脚本
		/// </summary>
		public string AIScript { get; private set; }

		/// <summary>
		/// 技能脚本
		/// </summary>
		public string SkillScript { get; private set; }


		public DRActorEntity()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			Group = text[++index];
			Name = text[++index];
			Title = text[++index];
			Icon = int.Parse(text[++index]);
			Desc = text[++index];
			Level = int.Parse(text[++index]);
			ActorType = int.Parse(text[++index]);
			Race = int.Parse(text[++index]);
			Sex = int.Parse(text[++index]);
			MonsterType = int.Parse(text[++index]);
			Quality = int.Parse(text[++index]);
			Speed = float.Parse(text[++index]);
			BSpeed = float.Parse(text[++index]);
			BornEffect = int.Parse(text[++index]);
			DeadEffect = int.Parse(text[++index]);
			string[] vector3Value = text[++index].Split(';');
			StagePos = new Vector3(float.Parse(vector3Value[0]), float.Parse(vector3Value[1]), float.Parse(vector3Value[2]));
			StageScale = int.Parse(text[++index]);
			AIFeature = text[++index];
			KillExp = int.Parse(text[++index]);
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
			VoiceAsset = text[++index];
			ModelAsset = text[++index];
			AiAtkDist = float.Parse(text[++index]);
			AiFollowDist = float.Parse(text[++index]);
			AiWaringDist = float.Parse(text[++index]);
			FindEnemyInterval = float.Parse(text[++index]);
			AIScript = text[++index];
			SkillScript = text[++index];
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

