using System;

namespace GameMain
{
    /// <summary>
    /// AI基类
    /// </summary>
    public abstract class ActorAIBase : IActorAI
    {
        private IActor owner;
        private AIModeType mode;
        private float atkDist;

        public AIModeType AIMode { get; protected set; }

        public AIStateType AIStateType { get; protected set; }

        public IActor Owner { get; }

        public float AttackDist { get; protected set; }

        public float FollowDist { get; protected set; }

        public float WaringDist { get; protected set; }

        public float FindEnemyInterval { get; protected set; }

        public float FindEnemyTimer { get; set; }

        protected ActorAIBase(ActorBase owner, AIModeType mode,float atkDist,float followDist,float waringDist,float findEnemyInterval)
        {
            this.Owner = owner;
            this.AIMode = mode;
            this.AttackDist = atkDist;
            this.FollowDist = followDist;
            this.WaringDist = waringDist;
            this.FindEnemyInterval = findEnemyInterval;
        }

        public abstract void Start();

        public abstract void Step();

        public abstract void Stop();

        public abstract void Clear();

        public abstract void ChangeAIState(AIStateType stateType);

        public virtual void ChangeAIMode(AIModeType mode)
        {
            if (AIMode == mode)
            {
                return;
            }


            AIMode = mode;

            switch (mode)
            {
                case AIModeType.Auto:
                    Start();
                    break;
                case AIModeType.Hand:
                    Stop();
                    break;
            }
        }

    }
}
