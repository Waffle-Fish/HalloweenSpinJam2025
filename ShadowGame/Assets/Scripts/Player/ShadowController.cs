using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
struct ShadowLightPair
{
    public Transform shadowPivot;
    public Transform lightSourceTransform;
}

public class ShadowController : MonoBehaviour
{
    [SerializeField] List<ShadowLightPair> shadows;

    [Header("Light Fall Off Equation")]
    [SerializeField][Range(-1f, 0f)] float exponentCoefficient = -0.01f;
    [SerializeField] float horizontalShift = 0.01f;
    [SerializeField] float verticalShift = -3;

    // Update is called once per frame
    void Update()
    {
        foreach (var sl_pair in shadows)
        {
            Vector2 lightDir = (sl_pair.shadowPivot.position - sl_pair.lightSourceTransform.position).normalized;
            float lightAngle = Mathf.Atan2(lightDir.y, lightDir.x) * Mathf.Rad2Deg;
            sl_pair.shadowPivot.rotation = Quaternion.Euler(0, 0, lightAngle - 90f);

            float newYScale = NewShadowYScale(Vector2.Distance(sl_pair.shadowPivot.transform.position, sl_pair.lightSourceTransform.position));
            sl_pair.shadowPivot.localScale = new(sl_pair.shadowPivot.localScale.x, newYScale);
        }
    }

    float NewShadowYScale(float dist)
    {
        float exponentVal = exponentCoefficient * dist + horizontalShift;
        float approximatelyE = 2.71f;
        float newYScale = Mathf.Pow(approximatelyE, exponentVal) + verticalShift;
        return Mathf.Clamp(newYScale, 0.3f, 10f);
    }
}
