
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
	public class DRScene : IDataRow
	{
		/// <summary>
		/// ID(场景编号)
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 名字
		/// </summary>
		public string SceneName { get; private set; }

		/// <summary>
		/// 场景类型
		/// </summary>
		public int SceneType { get; private set; }

		/// <summary>
		/// 资源名称
		/// </summary>
		public string AssetName { get; private set; }

		/// <summary>
		/// 背景音乐编号
		/// </summary>
		public int BackgroundMusicId { get; private set; }

		/// <summary>
		/// 玩家出生点
		/// </summary>
		public Vector3 PlayerSpawn { get; private set; }


		public DRScene()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			SceneName = text[++index];
			SceneType = int.Parse(text[++index]);
			AssetName = text[++index];
			BackgroundMusicId = int.Parse(text[++index]);
			string[] vector3Value = text[++index].Split(';');
			PlayerSpawn = new Vector3(float.Parse(vector3Value[0]), float.Parse(vector3Value[1]), float.Parse(vector3Value[2]));
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

