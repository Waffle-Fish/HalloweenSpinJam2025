using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    [SerializeField] Transform shadowPivot;
    [SerializeField] Transform lightSourceTransform;

    float shadowPivotOffset;

    [Header("Light Fall Off Equation")]
    [SerializeField][Range(-1f, 0f)] float exponentCoefficient = -0.01f;
    [SerializeField] float horizontalShift = 0.01f;
    [SerializeField] float verticalShift = -3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lightDir = (shadowPivot.position - lightSourceTransform.position).normalized;
        float lightAngle = Mathf.Atan2(lightDir.y, lightDir.x) * Mathf.Rad2Deg;
        shadowPivot.rotation = Quaternion.Euler(0, 0, lightAngle - 90f);

        UpdateShadowScale(Vector2.Distance(shadowPivot.transform.position, lightSourceTransform.position));
    }
    
    void UpdateShadowScale(float dist)
    {
        float exponentVal = exponentCoefficient * dist + horizontalShift;
        float approximatelyE = 2.71f;
        float newYScale = Mathf.Pow(approximatelyE, exponentVal) + verticalShift;
        newYScale = Mathf.Clamp(newYScale, 0.3f, 10f);
        shadowPivot.transform.localScale = new(shadowPivot.transform.localScale.x, newYScale);
    }
}
