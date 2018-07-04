
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DRRoleName : IDataRow
	{
		/// <summary>
		/// ID(场景编号)
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 名字
		/// </summary>
		public string RoleName { get; private set; }


		public DRRoleName()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			RoleName = text[++index];
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

