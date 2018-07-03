using FairyGUI;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    /// <summary>
    /// FairyGUI 界面组辅助器
    /// </summary>
    public class FairyGuiGroupHelper : UIGroupHelperBase
    {
        public const int DepthFactor = 10000;

        private int m_Depth = 0;
        private GComponent m_CachedUI = null;

        /// <summary>
        /// 设置界面组深度
        /// </summary>
        /// <param name="depth"></param>
        public override void SetDepth(int depth)
        {
            m_Depth = depth;
            SetSortingOrder(DepthFactor * depth);
        }

        private void Start()
        {
            transform.parent = GRoot.inst.rootContainer.gameObject.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;

            SetSortingOrder(DepthFactor * m_Depth);
        }

        private void SetSortingOrder(int depth)
        {
            FairyGuiForm[] forms = GetComponentsInChildren<FairyGuiForm>();
            for (int i = 0; i < forms.Length; i++)
            {
                forms[i].SetSortingOrder(depth,true);
            }
        }

    }
}
