namespace EventBusSystem
{
    public interface IEventParameter
    {

    }

    public class EventParameter<T> : IEventParameter
    {
        public T value;
    }
}

