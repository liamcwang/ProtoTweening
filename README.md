# ProtoTweening
Simple programmatic Unity tweening library API, with ability for developer to expand functionality.  
Best suited for prototyping or a "quick" one function implementation.  
This is also intended to be for *your* personal tweening needs. You can add new wrapper functions for anything you need, or use tweening on whatever you'd like to your hearts desire.  
Defining a custom tween is as easy as passing a custom Tween struct and Action<T> to Tween.Play.

Features:
- A simple tweening API for Unity tweenable datatypes (Vector2, Color, Quaternions, etc.)
- A set of standard easing functions.
- A set of standard wrappers for easy plug 'n play.
- Easy extensibility for any theoretical tweening purposes.
- Standard support for Material parameters and some UI.
- Easy to understand (Only 4 scripts, one with a lot of boilerplate)

**Example:**  
Linearly interpolate an object in 3D space in Unity, and have it bounce at the end.
```
using UnityEngine;
using ProtoTweening;

public class TweenExample : MonoBehaviour {
    void Start() {
        var startPos = gameObject.transform.position;
        var endPos = gameObject.transform.position - new Vector3(0, 5, 0);
        var targetTransform = gameObject.transform;
        Tween.PlayMove(
            targetTransform,
            startPos, 
            endPos, 
            1f, // duration of movement
            EaseType.EaseOutBounce
        );
    }
}
```
See TweenDemo for a more complex sequence of tweens.

## To Use
Simply download the repo and add the files to your existing Unity project.

## Custom Tweens
To add your own tweens, it's as simple as going to Tween.cs, adding a new tween type, new data if you'd like, and a new case for its combination in the switch-case of SelectLerpApply.

Example of a new case statement
```
case (TweenType.MyTweenType, Action<MyData> ApplyMyData): {
    LerpEffect = (t) => {
        var resultCustomData = MyLerp(
            tween.initial.MyData, 
            tween.end.MyData, 
            t
        );
        ApplyMyData(resultCustomData);
    };
} break;
```
