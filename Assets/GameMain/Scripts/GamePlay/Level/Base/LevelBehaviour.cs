using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 关卡行为
    /// </summary>
    public abstract class LevelBehaviour : MonoBehaviour
    {
        public int Id { get; set; }

        public abstract void Init();

        public abstract void Destroy();

        public abstract void Import(XmlObject pdata, bool pBuild);

        public abstract XmlObject Export();
    }
}
