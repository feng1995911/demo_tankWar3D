
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DRPoseRole : IDataRow
	{
		/// <summary>
		/// 职业编号
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 职业类型
		/// </summary>
		public int ProfessionType { get; private set; }

		/// <summary>
		/// 特效01
		/// </summary>
		public int Effect01 { get; private set; }

		/// <summary>
		/// 特效01延迟
		/// </summary>
		public float Effect01Delay { get; private set; }

		/// <summary>
		/// 特效01持续时间
		/// </summary>
		public float Effect01Duration { get; private set; }

		/// <summary>
		/// 特效02
		/// </summary>
		public int Effect02 { get; private set; }

		/// <summary>
		/// 特效02延迟
		/// </summary>
		public float Effect02Delay { get; private set; }

		/// <summary>
		/// 特效02持续时间
		/// </summary>
		public float Effect02Duration { get; private set; }

		/// <summary>
		/// 音效id
		/// </summary>
		public int SoundId { get; private set; }

		/// <summary>
		/// 音效延迟
		/// </summary>
		public float SoundDelay { get; private set; }


		public DRPoseRole()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			ProfessionType = int.Parse(text[++index]);
			Effect01 = int.Parse(text[++index]);
			Effect01Delay = float.Parse(text[++index]);
			Effect01Duration = float.Parse(text[++index]);
			Effect02 = int.Parse(text[++index]);
			Effect02Delay = float.Parse(text[++index]);
			Effect02Duration = float.Parse(text[++index]);
			SoundId = int.Parse(text[++index]);
			SoundDelay = float.Parse(text[++index]);
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

