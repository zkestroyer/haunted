using System.Collections.Generic;
using UnityEngine;

/// Attach to the fireplace root. The FBX includes a looping flame-shape animation
/// and green point light; this component adds a bright green HDR emission pulse.
[DisallowMultipleComponent]
public sealed class GreenFireFlicker : MonoBehaviour
{
    [SerializeField] private Renderer[] flameRenderers;
    [SerializeField] private Light fireLight;
    [SerializeField] private Color glowColor = new Color(0.015f, 1.0f, 0.025f, 1.0f);
    [SerializeField, Min(0f)] private float emissionStrength = 14f;
    [SerializeField, Min(0f)] private float lightBaseIntensity = 8f;
    [SerializeField, Min(0f)] private float lightFlicker = 0.38f;
    [SerializeField, Min(0.01f)] private float flickerSpeed = 3.2f;

    private MaterialPropertyBlock block;
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
    private float seed;

    private void Awake()
    {
        block = new MaterialPropertyBlock();
        seed = Random.value * 100f;

        // Only select flame meshes. Leaving the array empty must not make the entire mantel glow.
        if (flameRenderers == null || flameRenderers.Length == 0)
        {
            Renderer[] all = GetComponentsInChildren<Renderer>(true);
            List<Renderer> fireOnly = new List<Renderer>();
            foreach (Renderer r in all)
                if (r != null && r.name.ToLowerInvariant().Contains("flame"))
                    fireOnly.Add(r);
            flameRenderers = fireOnly.ToArray();
        }

        if (fireLight == null)
            fireLight = GetComponentInChildren<Light>(true);

        foreach (Renderer r in flameRenderers)
        {
            if (r == null) continue;
            foreach (Material m in r.sharedMaterials)
                if (m != null && m.HasProperty(EmissionColor))
                    m.EnableKeyword("_EMISSION");
        }
    }

    private void Update()
    {
        float t = Time.time * flickerSpeed + seed;
        float n = Mathf.PerlinNoise(t, seed);
        float pulse = 0.78f + 0.32f * n;
        Color emission = glowColor * (emissionStrength * pulse);

        foreach (Renderer r in flameRenderers)
        {
            if (r == null) continue;
            r.GetPropertyBlock(block);
            block.SetColor(EmissionColor, emission);
            r.SetPropertyBlock(block);
        }

        if (fireLight != null)
            fireLight.intensity = lightBaseIntensity * (1f + lightFlicker * (n - 0.5f));
    }
}
