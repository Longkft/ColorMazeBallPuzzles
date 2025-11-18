using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    [Header("Trail Settings")]
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private float trailTime = 0.25f;
    [SerializeField] private AnimationCurve widthCurve;

    [Header("Colors")]
    [SerializeField] private Gradient colorGradient;

    private void Awake()
    {
        SetupTrailRenderer();
    }

    private void SetupTrailRenderer()
    {
        trailRenderer.time = trailTime;
        trailRenderer.widthCurve = widthCurve;
        trailRenderer.colorGradient = colorGradient;

        // Material setup
        trailRenderer.material.shader = Shader.Find("Particles/Additive");
        trailRenderer.material.SetColor("_TintColor", Color.white);
    }

    public void UpdateTrailColor(Color newColor)
    {
        GradientColorKey[] colorKeys = new GradientColorKey[2];
        colorKeys[0].color = newColor;
        colorKeys[0].time = 0.0f;
        colorKeys[1].color = newColor;
        colorKeys[1].time = 1.0f;

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 0.0f;
        alphaKeys[1].alpha = 0.0f;
        alphaKeys[1].time = 1.0f;

        colorGradient.SetKeys(colorKeys, alphaKeys);
        trailRenderer.colorGradient = colorGradient;
    }
}
