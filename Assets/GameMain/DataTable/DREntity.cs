
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DREntity : IDataRow
	{
		/// <summary>
		/// 实体编号
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 所属组
		/// </summary>
		public string Group { get; private set; }

		/// <summary>
		/// 资源名称
		/// </summary>
		public string AssetName { get; private set; }


		public DREntity()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			Group = text[++index];
			AssetName = text[++index];
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

