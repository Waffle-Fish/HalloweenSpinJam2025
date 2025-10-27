using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] float range = 5f;
    [SerializeField] Vector2 center = Vector2.zero;
    [Tooltip("Speed 2 = 360 degrees in 1 second\nSpeed 1 = 360 degrees in 2 second\nSpeed 0.5 = 360 degrees in 4 second")]
    [SerializeField] float speed = 1f;
    [SerializeField] float timeOffset = 0;

    float time = 0;

    private void Start() {
        time += timeOffset;
    }
    // Update is called once per frame
    void Update()
    {
        time += Mathf.PI * Time.deltaTime * speed;
        transform.position = new Vector2(Mathf.Sin(time) + center.x, Mathf.Cos(time) + center.y) * range;
    }
}
