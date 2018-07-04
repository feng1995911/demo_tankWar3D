namespace GameMain
{
    public interface ICameraBehaviour
    {
        CameraBehaviourType Type
        {
            get;
        }

        /// <summary>
        /// 启用
        /// </summary>
        void Enable();

        /// <summary>
        /// 禁用
        /// </summary>
        void Disable();
    }
}
