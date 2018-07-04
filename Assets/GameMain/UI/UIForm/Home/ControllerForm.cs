using FairyGUI;
using GameFramework;

namespace GameMain
{
    public class ControllerForm : FairyGuiForm
    {
        private JoystickModule m_Joystick;
        private TouchPadModule m_TouchPad;

        private VirtualAxisBase m_HorizontalVirtualAxis;
        private VirtualAxisBase m_VerticalVirtualAxis;
        private VirtualAxisBase m_TouchPadXAxis;
        private VirtualAxisBase m_TouchPadYAxis;

        protected override void OnOpen(object userData)
        {
            base.OnInit(userData);

            m_Joystick = new JoystickModule(UI);
            m_Joystick.OnMove.Add(this.OnJoystickMove);
            m_Joystick.OnEnd.Add(this.OnJoystickEnd);

            m_TouchPad = new TouchPadModule(UI);
            m_TouchPad.OnMove.Add(this.OnTouchPadMove);
            m_TouchPad.OnEnd.Add(this.OnTouchPadEnd);

            //注册输入
            m_HorizontalVirtualAxis = new VirtualAxisBase(Constant.Input.HorizontalAxis);
            m_VerticalVirtualAxis = new VirtualAxisBase(Constant.Input.VerticalAxis);
            m_TouchPadXAxis = new VirtualAxisBase(Constant.Input.PadXAxis);
            m_TouchPadYAxis = new VirtualAxisBase(Constant.Input.PadYAxis);

            GameEntry.Input.RegisterVirtualAxis(m_HorizontalVirtualAxis);
            GameEntry.Input.RegisterVirtualAxis(m_VerticalVirtualAxis);
            GameEntry.Input.RegisterVirtualAxis(m_TouchPadXAxis);
            GameEntry.Input.RegisterVirtualAxis(m_TouchPadYAxis);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            m_TouchPad.Update();
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            m_Joystick.OnMove.Remove(this.OnJoystickMove);
            m_Joystick.OnEnd.Remove(this.OnJoystickEnd);

            m_TouchPad.OnMove.Remove(this.OnTouchPadMove);
            m_TouchPad.OnEnd.Remove(this.OnJoystickEnd);

            GameEntry.Input.UnRegisterVirtualAxis(m_HorizontalVirtualAxis);
            GameEntry.Input.UnRegisterVirtualAxis(m_VerticalVirtualAxis);
            GameEntry.Input.UnRegisterVirtualAxis(m_TouchPadXAxis);
            GameEntry.Input.UnRegisterVirtualAxis(m_TouchPadYAxis);
        }


        private void OnJoystickEnd()
        {
            m_HorizontalVirtualAxis.Update(0);
            m_VerticalVirtualAxis.Update(0);
        }

        private void OnJoystickMove(EventContext context)
        {
            JoystickEventData data = (JoystickEventData) context.data;
            //Log.Warning(data.DeltaX + "****" + data.DelatY + "****" + data.Degree);
            m_HorizontalVirtualAxis.Update(data.DeltaX);
            m_VerticalVirtualAxis.Update(data.DeltaY);
        }

        private void OnTouchPadEnd()
        {
            //Log.Warning("Pad end");
            m_TouchPadXAxis.Update(0);
            m_TouchPadYAxis.Update(0);
        }

        private void OnTouchPadMove(EventContext context)
        {
            TouchPadModuleData data = (TouchPadModuleData) context.data;
           // Log.Warning(data.DeltaX + "****" + data.DeltaY);
            m_TouchPadXAxis.Update(data.DeltaX);
            m_TouchPadYAxis.Update(data.DeltaY);
        }
    }
}
