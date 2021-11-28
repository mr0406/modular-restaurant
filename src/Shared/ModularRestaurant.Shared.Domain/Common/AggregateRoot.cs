namespace ModularRestaurant.Shared.Domain.Common
{
    public abstract class AggregateRoot<T> : Entity<T> where T : TypeId
    {
        public int Version { get; protected set; }
        
        private bool _versionIncremented;

        protected void IncrementVersion()
        {
            if (_versionIncremented)
                return;

            Version++;
            _versionIncremented = true;
        }
    }
}