
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DRUIForm : IDataRow
	{
		/// <summary>
		/// ID(界面编号)
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 资源名称
		/// </summary>
		public string AssetName { get; private set; }

		/// <summary>
		/// 界面组名称
		/// </summary>
		public string UIGroupName { get; private set; }

		/// <summary>
		/// 是否允许多个界面实例
		/// </summary>
		public bool AllowMultiInstance { get; private set; }

		/// <summary>
		/// 是否暂停被其覆盖的界面
		/// </summary>
		public bool PauseCoveredUIForm { get; private set; }


		public DRUIForm()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			AssetName = text[++index];
			UIGroupName = text[++index];
			AllowMultiInstance = bool.Parse(text[++index]);
			PauseCoveredUIForm = bool.Parse(text[++index]);
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

