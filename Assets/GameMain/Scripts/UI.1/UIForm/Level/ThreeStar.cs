using FairyGUI;
using FairyGUI.Utils;
using GameFramework;

namespace GameMain
{
    public class ThreeStar : GComponent
    {
        private Controller[] m_StarCtrl = null;

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            m_StarCtrl = new Controller[3];

            m_StarCtrl[0] = GetChild("star01").asCom.GetController("ctrl");
            m_StarCtrl[1] = GetChild("star02").asCom.GetController("ctrl");
            m_StarCtrl[2] = GetChild("star03").asCom.GetController("ctrl");
        }

        public void SetStar(int count)
        {
            if (count < 0 || count > 3)
            {
                Log.Error("Count is invalid");
                return;
            }

            for (int i = 0; i < m_StarCtrl.Length; i++)
            {
                if (i < count)
                {
                    m_StarCtrl[i].selectedIndex = 1;
                }
                else
                {
                    m_StarCtrl[i].selectedIndex = 0;
                }
            }
        } 


    }
}
