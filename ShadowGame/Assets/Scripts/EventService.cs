using UnityEngine;

public class EventService
{
    private static EventService _instance;
    public static EventService Instance
    {
        get
        {
            if (_instance == null) _instance = new EventService();
            return _instance;
        }
    }

    public EventController<float> OnHealthUpdated { get; private set; }
    public EventController OnDeath { get; private set; }

    public EventService()
    {
        OnHealthUpdated = new EventController<float>();
        OnDeath = new EventController();
    }
}
