
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DRBuffAttr : IDataRow
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
		/// 描述
		/// </summary>
		public string Desc { get; private set; }

		/// <summary>
		/// 属性1类型
		/// </summary>
		public int Attr1 { get; private set; }

		/// <summary>
		/// 属性1数值
		/// </summary>
		public int Value1 { get; private set; }

		/// <summary>
		/// 属性1数值类型
		/// </summary>
		public int ValueType1 { get; private set; }

		/// <summary>
		/// 属性2类型
		/// </summary>
		public int Attr2 { get; private set; }

		/// <summary>
		/// 属性2数值
		/// </summary>
		public int Value2 { get; private set; }

		/// <summary>
		/// 属性2数值类型
		/// </summary>
		public int ValueType2 { get; private set; }

		/// <summary>
		/// 属性3类型
		/// </summary>
		public int Attr3 { get; private set; }

		/// <summary>
		/// 属性3数值
		/// </summary>
		public int Value3 { get; private set; }

		/// <summary>
		/// 属性3数值类型
		/// </summary>
		public int ValueType3 { get; private set; }


		public DRBuffAttr()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			Name = text[++index];
			Desc = text[++index];
			Attr1 = int.Parse(text[++index]);
			Value1 = int.Parse(text[++index]);
			ValueType1 = int.Parse(text[++index]);
			Attr2 = int.Parse(text[++index]);
			Value2 = int.Parse(text[++index]);
			ValueType2 = int.Parse(text[++index]);
			Attr3 = int.Parse(text[++index]);
			Value3 = int.Parse(text[++index]);
			ValueType3 = int.Parse(text[++index]);
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

