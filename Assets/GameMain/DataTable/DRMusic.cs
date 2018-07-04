
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DRMusic : IDataRow
	{
		/// <summary>
		/// 音乐编号
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 资源名称
		/// </summary>
		public string AssetName { get; private set; }

		/// <summary>
		/// 优先级
		/// </summary>
		public int Priority { get; private set; }

		/// <summary>
		/// 是否循环
		/// </summary>
		public bool Loop { get; private set; }

		/// <summary>
		/// 音量(0~1)
		/// </summary>
		public float Volume { get; private set; }

		/// <summary>
		/// 淡入淡出时间
		/// </summary>
		public float FadeTime { get; private set; }


		public DRMusic()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			AssetName = text[++index];
			Priority = int.Parse(text[++index]);
			Loop = bool.Parse(text[++index]);
			Volume = float.Parse(text[++index]);
			FadeTime = float.Parse(text[++index]);
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

