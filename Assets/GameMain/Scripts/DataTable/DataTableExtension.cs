using System;
using GameFramework;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;

namespace GameMain
{
    /// <summary>
    /// 数据表组件扩展
    /// </summary>
    public static class DataTableExtension
    {
        private const string DataRowClassPrefixName = "GameMain.DR";
        private static readonly string[] ColumnSplit = new string[] { "\t" };

        /// <summary>
        /// 加载数据表
        /// </summary>
        /// <param name="dataTableComponent">数据表组件</param>
        /// <param name="dataTableName">数据表名字</param>
        /// <param name="userData">用户自定义数据</param>
        public static void LoadDataTable(this DataTableComponent dataTableComponent, string dataTableName, object userData = null)
        {
            if (string.IsNullOrEmpty(dataTableName))
            {
                Log.Warning("Data table name is invalid.");
                return;
            }

            string[] splitNames = dataTableName.Split('_');
            if (splitNames.Length > 2)
            {
                Log.Warning("Data table name is invalid.");
                return;
            }

            string dataRowClassName = DataRowClassPrefixName + splitNames[0];

            Type dataRowType = Type.GetType(dataRowClassName);
            if (dataRowType == null)
            {
                Log.Warning("Can not get data row type with class name '{0}'.", dataRowClassName);
                return;
            }

            string dataTableNameInType = splitNames.Length > 1 ? splitNames[1] : null;
            dataTableComponent.LoadDataTable(dataRowType, dataTableName, dataTableNameInType, AssetUtility.GetDataTableAsset(dataTableName), userData);
        }

        /// <summary>
        /// 重新加载已加载的数据表
        /// </summary>
        public static void ReloadDataTable(this DataTableComponent dataTableComponent)
        {
            DataTableBase[] allLoadedDataTables = dataTableComponent.GetAllDataTables();
            for (int i = 0; i < allLoadedDataTables.Length; i++)
            {
                Type dataTableType = allLoadedDataTables[i].Type;
                if (dataTableComponent.DestroyDataTable(dataTableType))
                {
                    string reloadTableName = dataTableType.ToString().Replace(DataRowClassPrefixName, "");
                    dataTableComponent.LoadDataTable(reloadTableName);
                    Log.Info("Reload DataTable:[{0}] success",reloadTableName);
                }
            }
        }


        public static string[] SplitDataRow(string dataRowText)
        {
            return dataRowText.Split(ColumnSplit, StringSplitOptions.None);
        }
    }
}
