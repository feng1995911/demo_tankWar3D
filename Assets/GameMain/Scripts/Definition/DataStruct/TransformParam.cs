using UnityEngine;

namespace GameMain
{
    public class TransformParam
    {
        public static TransformParam Default { get; } = new TransformParam();

        public Vector3 Position = Vector3.zero;
        public Vector3 EulerAngles = Vector3.zero;
        public Vector3 Scale = Vector3.one;

        public static TransformParam Create(Vector3 pos, Vector3 angle)
        {
            TransformParam data = new TransformParam
            {
                Position = pos,
                EulerAngles = angle,
                Scale = Vector3.one
            };
            return data;
        }

        public static TransformParam Create(Vector3 pos, Vector3 angle, Vector3 scale)
        {
            TransformParam data = new TransformParam
            {
                Position = pos,
                EulerAngles = angle,
                Scale = scale
            };
            return data;
        }

    }
}
