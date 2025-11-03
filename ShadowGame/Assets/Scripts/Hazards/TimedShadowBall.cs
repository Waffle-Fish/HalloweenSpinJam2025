using System.Collections;
using UnityEngine;

public class TimedShadowBall : ShadowBallBehavior
{
    [SerializeField][Range(0f, 10f)] float duration;
    [SerializeField] Transform fillBar;
    float timer = 0f;

    float fillBarMaxLength;

    private void Awake()
    {
        if (fillBar == null) Debug.LogError(name + " has no timer bar!");
        fillBarMaxLength = fillBar.localScale.y;
    }

    private void OnEnable()
    {
        timer = 0f;
        Vector3 fbls = fillBar.localScale;
        fillBar.localScale = new(fbls.x, fillBarMaxLength, fbls.z);
    }

    private void FixedUpdate()
    {
        float percentComplete = Mathf.Clamp(1 - (timer / duration), 0f, 1f);
        UpdateVisual(percentComplete);
        if (timer > duration)
        {
            Explode();
        }
        timer += Time.fixedDeltaTime;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (disappearAfterTouch && collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    private void Explode()
    {
        if (gameObject && gameObject.activeSelf)
        {
            PlayerHealth.Instance.UpdateHealth(-DamageDelt);
            gameObject.SetActive(false);
        }
    }
    
    private void UpdateVisual(float percent)
    {
        float newYScale = fillBarMaxLength * percent;
        Vector3 fbls = fillBar.localScale;
        fillBar.localScale = new(fbls.x, newYScale, fbls.z);
        float newYPos = (fillBar.transform.localScale.y - fillBarMaxLength) / 2f;
        Vector3 fbLocPos = fillBar.localPosition;
        fillBar.localPosition = new(fbLocPos.x, newYPos, fbLocPos.z);
    }
}
