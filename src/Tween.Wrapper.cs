using UnityEngine;
using UnityEngine.UI;

namespace ProtoTweening {

/// <summary>
/// Wrapper functions for tweens
/// </summary>
public partial struct Tween 
{
#region Material Support
    public static void PlayMaterialFloat(
        Material material,
        int propertyId,
        float initial, 
        float end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMaterialFloatAsync(material, propertyId, initial, end, duration, ease);
    }

    public static async Awaitable PlayMaterialFloatAsync(
        Material material,
        int propertyId, 
        float initial, 
        float end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        MaterialTarget materialTarget = new MaterialTarget(material, propertyId);
        Tween tween = new Tween() {
            type = TweenType.Float,
            easeType = ease,
            duration = duration
        };
        tween.initial.Float = initial;
        tween.end.Float = end;
        await PlayDefaultAsync<float>(materialTarget.ApplyFloat, tween);
    }

    public static void PlayMaterialInteger(
        Material material,
        int propertyId, 
        int initial, 
        int end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMaterialIntegerAsync(material, propertyId, initial, end, duration, ease);   
    }

    public static async Awaitable PlayMaterialIntegerAsync(
        Material material,
        int propertyId, 
        int initial, 
        int end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        MaterialTarget materialTarget = new MaterialTarget(material, propertyId);
        Tween tween = new Tween() {
            type = TweenType.Integer,
            easeType = ease,
            duration = duration
        };
        tween.initial.Integer = initial;
        tween.end.Integer = end;
        await PlayDefaultAsync<int>(materialTarget.ApplyInteger, tween);
    }

    public static void PlayMaterialVector(
        Material material,
        int propertyId, 
        Vector4 initial, 
        Vector4 end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMaterialVectorAsync(material, propertyId, initial, end, duration, ease);   
    }

    public static async Awaitable PlayMaterialVectorAsync(
        Material material,
        int propertyId, 
        Vector4 initial, 
        Vector4 end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        MaterialTarget materialTarget = new MaterialTarget(material, propertyId);
        Tween tween = new Tween() {
            type = TweenType.Vector4,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector4 = initial;
        tween.end.Vector4 = end;
        await PlayDefaultAsync<Vector4>(materialTarget.ApplyVector, tween);
    }

    public static void PlayMaterialColor(
        Material material,
        int propertyId, 
        Color initial, 
        Color end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMaterialColorAsync(material, propertyId, initial, end, duration, ease);
    }

    public static async Awaitable PlayMaterialColorAsync(
        Material material,
        int propertyId, 
        Color initial, 
        Color end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        MaterialTarget materialTarget = new MaterialTarget(material, propertyId);
        Tween tween = new Tween() {
            type = TweenType.Color,
            easeType = ease,
            duration = duration
        };
        tween.initial.Color = initial;
        tween.end.Color = end;
        await PlayDefaultAsync<Color>(materialTarget.ApplyColor, tween);
    }
    
    public static void PlayMaterialTextureOffset(
        Material material,
        int propertyId, 
        Vector2 initial, 
        Vector2 end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMaterialTextureOffsetAsync(material, propertyId, initial, end, duration, ease);
    }

    public static async Awaitable PlayMaterialTextureOffsetAsync(
        Material material,
        int propertyId, 
        Vector2 initial, 
        Vector2 end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        MaterialTarget materialTarget = new MaterialTarget(material, propertyId);
        Tween tween = new Tween() {
            type = TweenType.Vector2,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector2 = initial;
        tween.end.Vector2 = end;
        await PlayDefaultAsync<Vector2>(materialTarget.ApplyTextureOffset, tween);
    }
    
    public static void PlayMaterialTextureScale(
        Material material,
        int propertyId, 
        Vector2 initial, 
        Vector2 end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMaterialTextureScaleAsync(material, propertyId, initial, end, duration, ease);
    }

    public static async Awaitable PlayMaterialTextureScaleAsync(
        Material material,
        int propertyId, 
        Vector2 initial, 
        Vector2 end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        MaterialTarget materialTarget = new MaterialTarget(material, propertyId);
        Tween tween = new Tween() {
            type = TweenType.Vector2,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector2 = initial;
        tween.end.Vector2 = end;
        await PlayDefaultAsync<Vector2>(materialTarget.ApplyTextureScale, tween);
    }
#endregion

#region UI Support
    public static void PlayCanvasFade(
        CanvasGroup canvasGroup,
        float initial, 
        float end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayCanvasFadeAsync(canvasGroup, initial, end, duration, ease);
    }

    public static async Awaitable PlayCanvasFadeAsync(
        CanvasGroup canvasGroup, 
        float initial, 
        float end, 
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Float,
            easeType = ease,
            duration = duration
        };
        tween.initial.Float = initial;
        tween.end.Float = end;
        await PlayDefaultAsync<float>((n) => canvasGroup.alpha = n, tween);
    }

    public static void PlaySliderFill(
        Slider slider, 
        float initial, 
        float end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlaySliderFillAsync(slider, initial, end, duration, ease);
    }

    public static async Awaitable PlaySliderFillAsync(
        Slider slider, 
        float initial, 
        float end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Float,
            easeType = ease,
            duration = duration
        };
        tween.initial.Float = initial;
        tween.end.Float = end;
        await PlayDefaultAsync<float>(slider.SetValueWithoutNotify, tween);
    }

    public static void PlayImageFill(
        Image image, 
        float initial, 
        float end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayImageFillAsync(image, initial, end, duration, ease);
    }

    public static async Awaitable PlayImageFillAsync(
        Image image, 
        float initial, 
        float end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Float,
            easeType = ease,
            duration = duration
        };
        tween.initial.Float = initial;
        tween.end.Float = end;
        await PlayDefaultAsync<float>((n) => image.fillAmount = n, tween);
    }

    public static void PlayMoveUI(
        RectTransform rectTransform, 
        Vector2 initial, 
        Vector2 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMoveUIAsync(rectTransform, initial, end, duration, ease);
    }

    public static async Awaitable PlayMoveUIAsync(
        RectTransform rectTransform, 
        Vector2 initial, 
        Vector2 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        RectTransformTarget target = new(rectTransform); // This is demonstrably faster by about 110ns, but will require variants for each type of data we allow to be targetted
        Tween tween = new Tween() {
            type = TweenType.Vector2,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector2 = initial;
        tween.end.Vector2 = end;
        await PlayDefaultAsync<Vector2>(target.SetVector2D, tween);
    }

    public static void PlayRecolorUI(
        Graphic graphic, 
        Color initial, 
        Color end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayRecolorUIAsync(graphic, initial, end, duration, ease);
    }

    public static async Awaitable PlayRecolorUIAsync(
        Graphic graphic, 
        Color initial, 
        Color end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Color,
            easeType = ease,
            duration = duration
        };
        tween.initial.Color = initial;
        tween.end.Color = end;
        await PlayDefaultAsync<Color>((color) => graphic.color = color, tween);
    }
#endregion

#region Transform Support
    public static void PlayScale(
        Transform transform, 
        Vector3 initial, 
        Vector3 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayScaleAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayScaleAsync(
        Transform transform, 
        Vector3 initial, 
        Vector3 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Vector3,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector3 = initial;
        tween.end.Vector3 = end;
        await PlayDefaultAsync<Vector3>((scale) => transform.localScale = scale, tween);
    }

    public static void PlayRotate(
        Transform transform, 
        float initial, 
        float end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayRotateAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayRotateAsync(
        Transform transform, 
        float initial, 
        float end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Rotate2D,
            easeType = ease,
            duration = duration
        };
        tween.initial.Float = initial;
        tween.end.Float = end;
        await PlayDefaultAsync<Quaternion>((rot) => transform.rotation = rot, tween);
    }

    public static void PlayRotate(
        Transform transform, 
        Vector3 initial, 
        Vector3 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayRotateAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayRotateAsync(
        Transform transform, 
        Vector3  initial, 
        Vector3 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Rotate3D,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector3 = initial;
        tween.end.Vector3 = end;
        await PlayDefaultAsync<Quaternion>((rot) => transform.rotation = rot, tween);
    }

    public static void PlayRotate(
        Transform transform, 
        Quaternion initial, 
        Quaternion end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayRotateAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayRotateAsync(
        Transform transform, 
        Quaternion initial, 
        Quaternion end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.RotateQuat,
            easeType = ease,
            duration = duration
        };
        tween.initial.Quaternion = initial;
        tween.end.Quaternion = end;
        await PlayDefaultAsync<Quaternion>((rot) => transform.rotation = rot, tween);
    }
    
    public static void PlayRotateLocal(
        Transform transform, 
        float initial, 
        float end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayRotateLocalAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayRotateLocalAsync(
        Transform transform, 
        float initial, 
        float end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Rotate2D,
            easeType = ease,
            duration = duration
        };
        tween.initial.Float = initial;
        tween.end.Float = end;
        await PlayDefaultAsync<Quaternion>((rot) => transform.rotation = rot, tween);
    }

    public static void PlayRotateLocal(
        Transform transform, 
        Vector3 initial, 
        Vector3 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayRotateLocalAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayRotateLocalAsync(
        Transform transform, 
        Vector3  initial, 
        Vector3 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Rotate3D,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector3 = initial;
        tween.end.Vector3 = end;
        await PlayDefaultAsync<Quaternion>((rot) => transform.rotation = rot, tween);
    }

    public static void PlayRotateLocal(
        Transform transform, 
        Quaternion initial, 
        Quaternion end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayRotateLocalAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayRotateLocalAsync(
        Transform transform, 
        Quaternion initial, 
        Quaternion end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.RotateQuat,
            easeType = ease,
            duration = duration
        };
        tween.initial.Quaternion = initial;
        tween.end.Quaternion = end;
        await PlayDefaultAsync<Quaternion>((rot) => transform.localRotation = rot, tween);
    }

    public static void PlayMove(
        Transform transform, 
        Vector2 initial, 
        Vector2 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMoveAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayMoveAsync(
        Transform transform, 
        Vector2 initial, 
        Vector2 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Vector2,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector2 = initial;
        tween.end.Vector2 = end;
        await PlayDefaultAsync<Vector2>((vec2) => transform.position = vec2, tween);
    }
    
    public static void PlayMove(
        Transform transform, 
        Vector3 initial, 
        Vector3 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMoveAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayMoveAsync(
        Transform transform, 
        Vector3 initial, 
        Vector3 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Vector3,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector3 = initial;
        tween.end.Vector3 = end;
        await PlayDefaultAsync<Vector3>((vec3) => transform.position = vec3, tween);
    }

    public static void PlayMoveLocal(
        Transform transform, 
        Vector2 initial, 
        Vector2 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMoveLocalAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayMoveLocalAsync(
        Transform transform, 
        Vector2 initial, 
        Vector2 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Vector2,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector2 = initial;
        tween.end.Vector2 = end;
        await PlayDefaultAsync<Vector2>((vec2) => transform.position = vec2, tween);
    }

    public static void PlayMoveLocal(
        Transform transform, 
        Vector3 initial, 
        Vector3 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        _ = PlayMoveLocalAsync(transform, initial, end, duration, ease);
    }

    public static async Awaitable PlayMoveLocalAsync(
        Transform transform, 
        Vector3 initial, 
        Vector3 end,
        float duration, 
        EaseType ease = EaseType.Linear)
    {
        Tween tween = new Tween() {
            type = TweenType.Vector3,
            easeType = ease,
            duration = duration
        };
        tween.initial.Vector3 = initial;
        tween.end.Vector3 = end;
        await PlayDefaultAsync<Vector3>((vec3) => transform.localPosition = vec3, tween);
    }
#endregion
}
}