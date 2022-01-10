namespace Sule.BoatStack.EventBus
{
    public delegate void EventListener<in TEvent>(TEvent e);
}
