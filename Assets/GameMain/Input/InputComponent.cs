using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public delegate void OnAxisInput(Vector2 delta);
    public delegate void OnAxisInputEnd();
    public delegate void OnSkillClick(int pos);


    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Input")]
    public class InputComponent : GameFrameworkComponent,ICustomComponent
    {
        public event OnAxisInput OnAxisInput;
        public event OnAxisInputEnd OnAxisInputEnd;
        public event OnSkillClick OnSkillClick;

        [SerializeField]
        private CrossPlatformInputManager.ActiveInputMethod InputType = CrossPlatformInputManager.ActiveInputMethod.Hardware;

        private float m_InputX = 0;
        private float m_InputY = 0;
        private bool m_LastInputEnable = false;
        private bool m_Inited = false;

        public void Init()
        {
            SwitchActiveInput();
            m_Inited = true;
        }

        public void Clear()
        {
            
        }

        void Update()
        {
            if(!m_Inited)
                return;
            
            m_InputX = GetAxis(Constant.Input.HorizontalAxis);
            m_InputY = GetAxis(Constant.Input.VerticalAxis);
            
            if (Mathf.Abs(m_InputX) > 0.05f || Mathf.Abs(m_InputY) > 0.05f)
            {
                OnAxisInput?.Invoke(new Vector2(m_InputX, m_InputY));
                m_LastInputEnable = true;
            }
            else
            {
                if (m_LastInputEnable)
                {
                    OnAxisInputEnd?.Invoke();
                }
                m_LastInputEnable = false;
            }

            if (GetButtonDown(Constant.Input.KeyNum01))
            {
                OnSkillClick?.Invoke(1);
            }
            if (GetButtonDown(Constant.Input.KeyNum02))
            {
                OnSkillClick?.Invoke(2);
            }
            if (GetButtonDown(Constant.Input.KeyNum03))
            {
                OnSkillClick?.Invoke(3);
            }
            if (GetButtonDown(Constant.Input.KeyNum04))
            {
                OnSkillClick?.Invoke(4);
            }
            if (GetButtonDown(Constant.Input.KeyNum05))
            {
                OnSkillClick?.Invoke(5);
            }
        }

        /// <summary>
        /// 注册虚拟轴
        /// </summary>
        /// <param name="axis">虚拟轴</param>
        public void RegisterVirtualAxis(VirtualAxisBase axis)
        {
            if (axis == null)
            {
                Log.Error("Can no register null axis.");
                return;
            }
            CrossPlatformInputManager.RegisterVirtualAxis(axis);
        }

        /// <summary>
        /// 注册虚拟按钮
        /// </summary>
        /// <param name="button">虚拟按钮</param>
        public void RegisterVirtualButton(VirtualButton button)
        {
            if (button == null)
            {
                Log.Error("Can no register null button.");
                return;
            }
            CrossPlatformInputManager.RegisterVirtualButton(button);
        }

        /// <summary>
        /// 取消注册虚拟轴
        /// </summary>
        /// <param name="name">虚拟轴名称</param>
        public void UnRegisterVirtualAxis(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("name is invlid.");
                return;
            }
            CrossPlatformInputManager.UnRegisterVirtualAxis(name);
        }

        /// <summary>
        /// 注册虚拟按钮
        /// </summary>
        /// <param name="button">虚拟按钮</param>
        public void UnRegisterVirtualAxis(VirtualAxisBase virtualAxis)
        {
            if (virtualAxis == null)
            {
                Log.Error("virtualAxis is null.");
                return;
            }

            if (string.IsNullOrEmpty(virtualAxis.Name))
            {
                Log.Error("name is invlid.");
                return;
            }

            CrossPlatformInputManager.UnRegisterVirtualAxis(virtualAxis.Name);
        }

        /// <summary>
        /// 取消注册虚拟按钮
        /// </summary>
        /// <param name="name">虚拟按钮名称</param>
        public void UnRegisterVirtualButton(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("name is invlid.");
                return;
            }
            CrossPlatformInputManager.UnRegisterVirtualButton(name);
        }

        /// <summary>
        /// 取消注册虚拟按钮
        /// </summary>
        /// <param name="name">虚拟按钮名称</param>
        public void UnRegisterVirtualButton(VirtualButton virtualButton)
        {
            if (virtualButton == null)
            {
                Log.Error("virtualButton is null.");
                return;
            }

            if (string.IsNullOrEmpty(virtualButton.Name))
            {
                Log.Error("name is invlid.");
                return;
            }
            CrossPlatformInputManager.UnRegisterVirtualButton(name);
        }

        /// <summary>
        /// 获取虚拟轴
        /// </summary>
        /// <param name="name">虚拟轴</param>
        /// <returns></returns>
        public VirtualAxisBase GetVirtualAxis(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("name is invlid.");
                return null;
            }
            return CrossPlatformInputManager.VirtualAxisReference(name) as VirtualAxisBase;
        }

        /// <summary>
        /// 获取轴系数
        /// </summary>
        public float GetAxis(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("name is invlid.");
                return 0;
            }

            return CrossPlatformInputManager.GetAxis(name);
        }

        /// <summary>
        /// 获取原始轴系数
        /// </summary>
        public float GetAxisRaw(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("name is invlid.");
                return 0;
            }

            return CrossPlatformInputManager.GetAxisRaw(name);
        }

        /// <summary>
        /// 获取按钮
        /// </summary>
        public static bool GetButton(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("name is invlid.");
                return false;
            }

            return CrossPlatformInputManager.GetButton(name);
        }

        /// <summary>
        /// 获取按钮按下
        /// </summary>
        public static bool GetButtonDown(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("name is invlid.");
                return false;
            }

            return CrossPlatformInputManager.GetButtonDown(name);
        }

        /// <summary>
        /// 获取按钮抬起
        /// </summary>
        public static bool GetButtonUp(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("name is invlid.");
                return false;
            }

            return CrossPlatformInputManager.GetButtonUp(name);
        }

        private void SwitchActiveInput()
        {
#if UNITY_EDITOR
            CrossPlatformInputManager.SwitchActiveInputMethod(InputType);
#else
            if (Application.isMobilePlatform)
            {
                CrossPlatformInputManager.SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod.Touch);
            }
            else
            {
                CrossPlatformInputManager.SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod.Hardware);
            }
#endif
        }

    }
}
