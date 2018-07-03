using System;
using GameFramework;

namespace GameMain
{
    /// <summary>
    /// 登陆界面数据
    /// </summary>
    public class LoginFormData
    {
        /// <summary>
        /// 游戏版本
        /// </summary>
        public string Version
        {
            get;
            set;
        }

        /// <summary>
        /// 游戏公告
        /// </summary>
        public string Notice
        {
            get;
            set;
        }

        /// <summary>
        /// 点击登陆(返回账号和密码)
        /// </summary>
        public Func<string,string,bool> OnClickLogin
        {
            get;
            set;
        }

        /// <summary>
        /// 点击注册(返回账号和密码)
        /// </summary>
        public Func<string,string,Action,bool> OnClickRegister
        {
            get;
            set;
        }

    }
}
