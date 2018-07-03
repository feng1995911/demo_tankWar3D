using FairyGUI;
using UnityEngine;

namespace GameMain.UI.Base
{
    public class FairyGuiStage : MonoBehaviour
    {
        void Awake()
        {
            Stage.inst.gameObject.SetActive(true);
            Stage.inst.gameObject.transform.SetParent(transform);
        }
    }
}
