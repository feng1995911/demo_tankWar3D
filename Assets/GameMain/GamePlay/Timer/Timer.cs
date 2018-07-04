using System;

namespace GameMain
{
    /// <summary>
    /// 计时器
    /// </summary>
    public class Timer
    {
        public int key;
        public Action callback;
        public float callTime;
        public float startTime;
        public int tick;
        public int currTick;
        public float currTime;

        public bool pause = false;

        public float GetLeftTime()
        {
            return currTime - startTime > 0 ? currTime - startTime : 0;
        }
    }
}
