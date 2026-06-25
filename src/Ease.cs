using System;
using UnityEngine;

namespace ProtoTweening {
public enum EaseType {
    Linear, 
    // Sine
    EaseInSine, 
    EaseOutSine, 
    EaseInOutSine,
    // Cubic
    EaseInCubic,
    EaseOutCubic,
    EaseInOutCubic,
    // Circle
    EaseInCircle,
    EaseOutCircle,
    EaseInOutCircle,
    // Elastic
    EaseInElastic,
    EaseOutElastic,
    EaseInOutElastic,
    // Bounce
    EaseInBounce,
    EaseOutBounce,
    EaseInOutBounce,
}

public static class Ease {
    // Elastic constants
    const float ec1 = (2f * Mathf.PI) / 3f; // elastic constant 1
    const float ec2 = (2f * Mathf.PI) / 4.5f; // elastic constant 2
    // Bounce constants
    const float bc = 7.5625f; // Bounciness
    const float bd = 2.75f; // Bounce divisions

    /// <summary>
    /// Returns an ease method based on the ease type provided
    /// </summary>
    public static Func<float, float> SelectMethod(EaseType easeType) =>
    easeType switch
    {
        EaseType.Linear => 
            (t) => t,

        EaseType.EaseInSine =>
            (t) => (float) (1 - Math.Cos((t * Math.PI) / 2)),

        EaseType.EaseOutSine =>
            (t) => (float) (Math.Sin((t * Math.PI) / 2)),

        EaseType.EaseInOutSine =>
            (t) => (float) (-(Math.Cos(Math.PI * t) - 1) / 2),

        EaseType.EaseInCubic =>
            (t) => t * t * t,

        EaseType.EaseOutCubic =>
            (t) => (float) (1 - Math.Pow(1 - t, 3)),

        EaseType.EaseInOutCubic =>
            (t) => (float) (t < 0.5 
                ? (4 * t * t * t) 
                : (1 - Math.Pow(-2 * t + 2, 3) / 2)),

        EaseType.EaseInCircle =>
            (t) => (float) (1 - Math.Sqrt(1 - Math.Pow(t, 2))),

        EaseType.EaseOutCircle =>
            (t) => (float) (Math.Sqrt(1 - Math.Pow(t - 1, 2))),

        EaseType.EaseInOutCircle =>
            (t) => (float) (t < 0.5
                ? (1 - Math.Sqrt(1 - Math.Pow(2 * t, 2))) / 2
                : (Math.Sqrt(1 - Math.Pow(-2 * t + 2, 2)) + 1) / 2),

        EaseType.EaseInElastic =>
            (t) => (float) (t == 0 
                ? 0 
                : t == 1 
                ? 1
                : -Math.Pow(2, 10 * t - 10) * Math.Sin((t * 10 - 10.75) * ec1)),

        EaseType.EaseOutElastic =>
            (t) => t == 0 
                ? 0
                : t == 1 
                ? 1
                : Mathf.Pow(2f, -10f * t) * Mathf.Sin((t * 10f - 0.75f) * ec1) + 1f,

        EaseType.EaseInOutElastic =>
            (t) => t == 0
                ? 0f
                : t == 1
                ? 1f
                : t < 0.5
                ? -(Mathf.Pow(2f, 20f * t - 10f) * Mathf.Sin((20f * t - 11.125f) * ec2)) / 2f
                : (Mathf.Pow(2f, -20f * t + 10f) * Mathf.Sin((20f * t - 11.125f) * ec2)) / 2f + 1f,

        EaseType.EaseInBounce =>
            (t) => 1 - EaseOutBounce(1 - t),

        EaseType.EaseOutBounce =>
            (t) => EaseOutBounce(t),
            
        EaseType.EaseInOutBounce =>
            (t) => t < 0.5
                    ? (1 - EaseOutBounce(1 - 2 * t)) / 2
                    : (1 + EaseOutBounce(2 * t - 1)) / 2,

        _ => throw new NotImplementedException()
    };

    static float EaseOutBounce(float t)
    {
        if (t < 1 / bd) {
            return bc * t * t;
        } else if (t < 2 / bd) {
            return bc * (t -= 1.5f / bd) * t + 0.75f;
        } else if (t < 2.5 / bd) {
            return bc * (t -= 2.25f / bd) * t + 0.9375f;
        } else {
            return bc * (t -= 2.625f / bd) * t + 0.984375f;
        }
    }
}
}
