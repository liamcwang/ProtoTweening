using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace ProtoTweening  {

// This appeared to improve a tween by a demonstrably faster amount, but such targets are not necessary by default.
public readonly struct RectTransformTarget 
{
    public readonly RectTransform transform;
    public RectTransformTarget(RectTransform transform) => 
        this.transform = transform;
    public void SetVector2D(Vector2 vec2) => 
        transform.anchoredPosition = vec2;
}

public readonly struct MaterialTarget {
    public readonly Material material;
    public readonly int propertyId;

    public MaterialTarget(Material material, int propertyId) 
    {
        this.material = material;
        this.propertyId = propertyId;
    }
    
    public MaterialTarget(Material material, string propertyName) 
    {
        this.material = material;
        this.propertyId = Shader.PropertyToID(propertyName);
    }

    public void ApplyInteger(int n) => 
        material.SetInteger(propertyId, n);

    public void ApplyFloat(float n) =>
        material.SetFloat(propertyId, n);

    public void ApplyVector(Vector4 vec4) =>
        material.SetVector(propertyId, vec4);

    public void ApplyColor(Color color) =>
        material.SetColor(propertyId, color);
    
    public void ApplyTextureOffset(Vector2 offset) =>
        material.SetTextureOffset(propertyId, offset);

    public void ApplyTextureScale(Vector2 offset) =>
        material.SetTextureScale(propertyId, offset);
}

}