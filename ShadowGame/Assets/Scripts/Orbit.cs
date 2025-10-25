using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] float range = 5f;
    [SerializeField] Vector2 center = Vector2.zero;
    [Tooltip("Speed 1 = 180 degrees in 1 second")]
    [SerializeField] float speed = 1f;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Mathf.PI * Time.deltaTime * speed;
        transform.position = new Vector2(Mathf.Sin(time) + center.x, Mathf.Cos(time) + center.y) * range;
    }
}
