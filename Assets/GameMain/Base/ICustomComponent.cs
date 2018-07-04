using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMain
{
    /// <summary>
    /// 自定义组件接口
    /// </summary>
    public interface ICustomComponent
    {
        void Init();

        void Clear();
    }
}
