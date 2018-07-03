namespace GameMain
{
    public class ActorManager : IActorManager
    {
        public T CreatePlayer<T>() where T : IActor
        {
            return default(T);
        }
    }
}
