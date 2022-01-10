using System.Collections.Generic;

namespace Sule.BoatStack.EventBus
{
    public static class EventBus<TEvent>
    {
        private static readonly List<EventListener<TEvent>> Listeners = new List<EventListener<TEvent>>();

        public static void AddListener(EventListener<TEvent> listener)
        {
            Listeners.Add(listener);
        }

        public static void RemoveListener(EventListener<TEvent> listener)
        {
            Listeners.Remove(listener);
        }

        public static void Emit(TEvent e)
        {
            foreach (var listener in Listeners)
            {
                listener.Invoke(e);
            }
        }
    }
}
