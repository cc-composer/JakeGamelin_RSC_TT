using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAnimations : MonoBehaviour
{
    Animation[] animations;
    MeshRenderer[] meshRenderers;
    Light[] lights;

    private void Start()
    {
        animations = GetComponentsInChildren<Animation>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        lights = GetComponentsInChildren<Light>();
    }

    void AnimationStart()
    {
        foreach (Animation animation in animations)
        {
            animation.Play();
        }

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = Random.ColorHSV();
        }

        foreach (Light light in lights)
        {
            light.color = Random.ColorHSV();
        }
    }
}
