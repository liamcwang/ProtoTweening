using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace ProtoTweening  {
public enum TweenType {
    Integer,
    Float,
    Vector2,
    Vector3,
    Vector4,
    Color,
    Rotate2D, 
    Rotate3D,
    RotateQuat,
}

public partial struct Tween
{
    public TweenType type;
    public EaseType easeType;
    public float duration;

    // C/C++ union pattern
    [StructLayout(LayoutKind.Explicit)]
    public struct TweenUnion {
        [FieldOffset(0)] public int Integer;
        [FieldOffset(0)] public float Float;
        [FieldOffset(0)] public Vector2 Vector2;
        [FieldOffset(0)] public Vector3 Vector3;
        [FieldOffset(0)] public Vector4 Vector4;
        [FieldOffset(0)] public Color Color;
        [FieldOffset(0)] public float Rotation2D;
        [FieldOffset(0)] public Vector3 Rotation3D;
        [FieldOffset(0)] public Quaternion Quaternion;
    }
    public TweenUnion initial;
    public TweenUnion end;

    public static async void Play(Action<float> LerpApply, Tween tween)
    {
        _ = PlayAsync(LerpApply, tween);
    }

    public static async Awaitable PlayAsync(Action<float> LerpApply, Tween tween)
    {
        Func<float, float> EaseMethod = Ease.SelectMethod(tween.easeType);
        float durationElapsing = 0;
        float t = 0;
        // Execute effect
        while(t < 1)
        {
            float ease_t = EaseMethod(t);
            LerpApply(ease_t);
            durationElapsing += Time.deltaTime;
            t = durationElapsing / tween.duration;
            await Awaitable.NextFrameAsync();
        }
        LerpApply(1);
    }

    /// <summary>
    /// Default constructor for a LerpApply
    /// Permits Play Async to be defined with fewer assumptions
    /// While still retaining the powerful defaults
    /// </summary>
    public static async Awaitable PlayDefaultAsync<T>(Action<T> Apply, Tween tween)
    {
        Action<float> LerpApply = SelectLerpApply(Apply, tween);
        await PlayAsync(LerpApply, tween);
    }

    /// <summary>
    /// Selects the lerp method that will apply to the target
    /// Provides powerful defaults that interface with Unity structures
    /// </summary>
    static Action<float> SelectLerpApply<T>(Action<T> Apply, Tween tween)
    {
        #if UNITY_EDITOR
        bool effectImplemented = Apply != null;
        if (!effectImplemented) {
            // Assert does not stop the flow of the program, but it does show up bright red
            Debug.Assert(effectImplemented, $"Tween type {tween.type} on {Apply.GetType()} has not been implemented! Leaving!");
            return null;
        }
        #endif
        Action<float> LerpEffect = null;
        switch (tween.type, Apply)
        {
            case (TweenType.Integer, Action<int> ApplyInt): {
                LerpEffect = (t) => {
                    int resultInteger = (int) Mathf.LerpUnclamped(
                        tween.initial.Integer,
                        tween.end.Integer, 
                        t
                    );
                    ApplyInt(resultInteger);
                };
            } break;
            case (TweenType.Float, Action<float> ApplyFloat): {
                LerpEffect = (t) => {
                    float resultFloat = Mathf.LerpUnclamped(
                        tween.initial.Float, 
                        tween.end.Float, 
                        t
                    );
                    ApplyFloat(resultFloat);
                };
            } break;
            case (TweenType.Vector2, Action<Vector2> ApplyVec2): {
                LerpEffect = (t) => {
                    Vector2 resultVector = Vector2.LerpUnclamped(
                        tween.initial.Vector2, 
                        tween.end.Vector2, 
                        t
                    );
                    ApplyVec2(resultVector);
                };
            } break;
            case (TweenType.Vector3, Action<Vector3> ApplyVec3): {
                LerpEffect = (t) => {
                    Vector3 resultVector = Vector3.LerpUnclamped(
                        tween.initial.Vector3, 
                        tween.end.Vector3, 
                        t
                    );
                    ApplyVec3(resultVector);
                };
            } break;
            case (TweenType.Vector4, Action<Vector4> ApplyVec4): {
                LerpEffect = (t) => {
                    Vector4 resultVector = Vector4.LerpUnclamped(
                        tween.initial.Vector4, 
                        tween.end.Vector4, 
                        t
                    );
                    ApplyVec4(resultVector);
                };
            } break;
            case (TweenType.Color, Action<Color> ApplyColor): {
                LerpEffect = (t) => {
                    Color resultColor = Color.LerpUnclamped(
                        tween.initial.Color, 
                        tween.end.Color, 
                        t
                    );
                    ApplyColor(resultColor);
                };
            } break;
            case (TweenType.Rotate2D, Action<Quaternion> ApplyRotation): {
                LerpEffect = (t) => {
                    var resultRotation = Mathf.LerpUnclamped(
                        tween.initial.Rotation2D, 
                        tween.end.Rotation2D, 
                        t
                    );
                    var resultQuat = Quaternion.Euler(0, 0, resultRotation);
                    ApplyRotation(resultQuat);
                };
            } break;
            case (TweenType.Rotate3D, Action<Quaternion> ApplyRotation): {
                LerpEffect = (t) => {
                    var resultRotation = Vector3.LerpUnclamped(
                        tween.initial.Rotation3D, 
                        tween.end.Rotation3D, 
                        t
                    );
                    var resultQuat = Quaternion.Euler(resultRotation);
                    ApplyRotation(resultQuat);
                };
            } break;
            case (TweenType.RotateQuat, Action<Quaternion> ApplyRotation): {
                LerpEffect = (t) => {
                    var resultQuat = Quaternion.LerpUnclamped(
                        tween.initial.Quaternion, 
                        tween.end.Quaternion, 
                        t
                    );
                    ApplyRotation(resultQuat);
                };
            } break;
        }
        return LerpEffect;
    }
}
}