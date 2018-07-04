using DG.Tweening;
using FairyGUI;
using UnityEngine;

namespace GameMain
{
    public class JoystickEventData
    {
        public float DeltaX { get; set; }
        public float DeltaY { get; set; }
        public float Degree { get; set; }
    }

    public class JoystickModule : EventDispatcher
    {
        private float m_InitX;
        private float m_InitY;
        private float m_startStageX;
        private float m_startStageY;
        private float m_lastStageX;
        private float m_lastStageY;

        private GButton m_button;
        private GObject m_touchArea;
        private GObject m_thumb;
        private GObject m_center;
        private Controller m_controller;

        private int m_touchId;
        private Tweener m_tweener;
        private JoystickEventData m_data;

        public EventListener OnMove { get; private set; }
        public EventListener OnEnd { get; private set; }

        public int Radius { get; set; }

        public JoystickModule(GComponent mainView)
        {
            OnMove = new EventListener(this, "onMove");
            OnEnd = new EventListener(this, "onEnd");

            m_button = mainView.GetChild("joystick").asButton;
            m_button.changeStateOnClick = false;
            m_thumb = m_button.GetChild("thumb");
            m_touchArea = mainView.GetChild("joystick_touch");
            m_center = mainView.GetChild("joystick_center");
            m_controller = mainView.GetController("joystick");
            m_controller.selectedIndex = 1;

            m_InitX = m_center.x + m_center.width / 2;
            m_InitY = m_center.y + m_center.height / 2;
            m_touchId = -1;
            Radius = 150;
            m_data = new JoystickEventData();

            m_touchArea.onTouchBegin.Add(this.OnTouchBegin);
            m_touchArea.onTouchMove.Add(this.OnTouchMove);
            m_touchArea.onTouchEnd.Add(this.OnTouchEnd);
        }

        public void Trigger(EventContext context)
        {
            OnTouchBegin(context);
        }

        private void OnTouchBegin(EventContext context)
        {
            if (m_touchId == -1)//First touch
            {
                InputEvent inputEvt = (InputEvent)context.data;
                m_touchId = inputEvt.touchId;

                m_controller.selectedIndex = 0;

                if (m_tweener != null)
                {
                    m_tweener.Kill();
                    m_tweener = null;
                }

                Vector2 pt = GRoot.inst.GlobalToLocal(new Vector2(inputEvt.x, inputEvt.y));
                float bx = pt.x;
                float by = pt.y;
                m_button.selected = true;

                if (bx < 0)
                    bx = 0;
                else if (bx > m_touchArea.width)
                    bx = m_touchArea.width;

                if (by > GRoot.inst.height)
                    by = GRoot.inst.height;
                else if (by < m_touchArea.y)
                    by = m_touchArea.y;

                m_lastStageX = bx;
                m_lastStageY = by;
                m_startStageX = bx;
                m_startStageY = by;

                m_center.visible = true;
                m_center.SetXY(bx - m_center.width / 2, by - m_center.height / 2);
                m_button.SetXY(bx - m_button.width / 2, by - m_button.height / 2);

                float deltaX = bx - m_InitX;
                float deltaY = by - m_InitY;
                float degrees = Mathf.Atan2(deltaY, deltaX) * 180 / Mathf.PI;
                //_thumb.rotation = degrees + 90;

                context.CaptureTouch();
            }
        }

        private void OnTouchEnd(EventContext context)
        {
            InputEvent inputEvt = (InputEvent)context.data;
            if (m_touchId != -1 && inputEvt.touchId == m_touchId)
            {
                m_controller.selectedIndex = 1;

                m_touchId = -1;
               // _thumb.rotation = _thumb.rotation + 180;
                m_center.visible = false;
                m_tweener = m_button.TweenMove(new Vector2(m_InitX - m_button.width / 2, m_InitY - m_button.height / 2), 0.3f).OnComplete(() =>
                {
                    m_tweener = null;
                    m_button.selected = false;
                    m_thumb.rotation = 0;
                    m_center.visible = true;
                    m_center.SetXY(m_InitX - m_center.width / 2, m_InitY - m_center.height / 2);
                }
                );

                this.OnEnd.Call();
            }
        }

        private void OnTouchMove(EventContext context)
        {
            InputEvent inputEvt = (InputEvent)context.data;
            if (m_touchId != -1 && inputEvt.touchId == m_touchId)
            {
                Vector2 pt = GRoot.inst.GlobalToLocal(new Vector2(inputEvt.x, inputEvt.y));
                float bx = pt.x;
                float by = pt.y;
                float moveX = bx - m_lastStageX;
                float moveY = by - m_lastStageY;
                m_lastStageX = bx;
                m_lastStageY = by;
                float buttonX = m_button.x + moveX;
                float buttonY = m_button.y + moveY;

                float offsetX = buttonX + m_button.width / 2 - m_startStageX;
                float offsetY = buttonY + m_button.height / 2 - m_startStageY;

                float rad = Mathf.Atan2(offsetY, offsetX);
                float degree = rad * 180 / Mathf.PI;
                //_thumb.rotation = degree + 90;

                float maxX = Radius * Mathf.Cos(rad);
                float maxY = Radius * Mathf.Sin(rad);
                if (Mathf.Abs(offsetX) > Mathf.Abs(maxX))
                    offsetX = maxX;
                if (Mathf.Abs(offsetY) > Mathf.Abs(maxY))
                    offsetY = maxY;

                buttonX = m_startStageX + offsetX;
                buttonY = m_startStageY + offsetY;
                if (buttonX < 0)
                    buttonX = 0;
                if (buttonY > GRoot.inst.height)
                    buttonY = GRoot.inst.height;

                m_button.SetXY(buttonX - m_button.width / 2, buttonY - m_button.height / 2);

                m_data.DeltaX = offsetX/Radius * 1;
                m_data.DeltaY = offsetY/Radius * -1;
                m_data.Degree = degree;
                this.OnMove.Call(m_data);
            }
        }
    }
}
