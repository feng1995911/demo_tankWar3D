using FairyGUI;
using UnityEngine;

namespace GameMain
{
    public class TouchPadModuleData
    {
        public float DeltaX { get; set; }
        public float DeltaY { get; set; }
    }

    public class TouchPadModule : EventDispatcher
    {
        public float Xsensitivity { get; set; } = 1f;
        public float Ysensitivity { get; set; } = 1f;

        private Vector2 m_PreviousTouchPos;
        private Vector2 m_LastTouchPos;
        private TouchPadModuleData m_Data;
        private int m_touchId = -1;
        private bool m_Dragging = false;

        private GObject m_TouchPad;


        public EventListener OnMove { get; private set; }
        public EventListener OnEnd { get; private set; }


        public TouchPadModule(GComponent mainView)
        {
            OnMove = new EventListener(this, "onMove");
            OnEnd = new EventListener(this, "onEnd");

            m_TouchPad = mainView.GetChild("touchPad");

            m_Data = new TouchPadModuleData();

            m_TouchPad.onTouchBegin.Add(this.OnTouchBegin);
            m_TouchPad.onTouchMove.Add(this.OnTouchMove);
            m_TouchPad.onTouchEnd.Add(this.OnTouchEnd);
        }

        public void Update()
        {
            if (!m_Dragging)
            {
                return;
            }

            Vector2 pointerDelta;
            pointerDelta.x = (m_LastTouchPos.x - m_PreviousTouchPos.x) * Xsensitivity;
            pointerDelta.y = (m_LastTouchPos.y - m_PreviousTouchPos.y) * Ysensitivity;
            m_PreviousTouchPos = m_LastTouchPos;

            pointerDelta = pointerDelta.normalized;
            m_Data.DeltaX = pointerDelta.x;
            m_Data.DeltaY = pointerDelta.y * -1;
            this.OnMove.Call(m_Data);
        }

        public void Tigger(EventContext context)
        {
            OnTouchBegin(context);
        }

        private void OnTouchBegin(EventContext context)
        {
            if (m_touchId == -1) //First touch
            {
                InputEvent inputEvt = (InputEvent) context.data;
                m_touchId = inputEvt.touchId;
                m_Dragging = true;

                m_PreviousTouchPos = GRoot.inst.GlobalToLocal(new Vector2(inputEvt.x, inputEvt.y));

                context.CaptureTouch();
            }
        }

        private void OnTouchEnd(EventContext context)
        {
            InputEvent inputEvt = (InputEvent)context.data;
            if (m_touchId != -1 && inputEvt.touchId == m_touchId)
            {
                m_Dragging = false;
                m_touchId = -1;
                this.OnEnd.Call();
            }
        }

        private void OnTouchMove(EventContext context)
        {
            InputEvent inputEvt = (InputEvent)context.data;
            if (m_touchId != -1 && inputEvt.touchId == m_touchId)
            {
                m_LastTouchPos = GRoot.inst.GlobalToLocal(new Vector2(inputEvt.x, inputEvt.y));

                //Vector2 pointerDelta;
                //pointerDelta.x = (touchPos.x - m_PreviousTouchPos.x)*Xsensitivity;
                //pointerDelta.y = (touchPos.y - m_PreviousTouchPos.y)*Ysensitivity;
                //m_PreviousTouchPos = touchPos;

                //pointerDelta = pointerDelta.normalized;
                //m_Data.DeltaX = pointerDelta.x;
                //m_Data.DeltaY = pointerDelta.y * -1;
                //this.OnMove.Call(m_Data);
            }
        }

    }
}
