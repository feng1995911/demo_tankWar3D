using GameFramework;
using System.Collections.Generic;

namespace GameMain
{
    public class RoleCreateFormData
    {
        /// <summary>
        /// 随机名字数据
        /// </summary>
        public Queue<string> RandomNameQueue
        {
            get;
            set;
        }

        /// <summary>
        /// 点击职业类型按钮，参数：1 剑士 2 法师 3 射手
        /// </summary>
        public GameFrameworkAction<int> OnClickRoleType
        {
            get;
            set;
        }

        /// <summary>
        /// 点击创建角色，参数：角色名字
        /// </summary>
        public GameFrameworkAction<string> OnClickCreateRole
        {
            get;
            set;
        }

    }
}
