using UnityEngine;
using ProtoTweening;

// See TweenDemo scene in Unity to observe
public class TweenDemo : MonoBehaviour
{
    public GameObject target;
    readonly int shaderId = Shader.PropertyToID("_BaseColor"); // Color swapping will only work on URP shader

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Press 1
        {
            var targetTransform = target.transform; 
            var startPos = targetTransform.position;
            var endPos = targetTransform.position + new Vector3(0, 2, 0);
            await Tween.PlayMoveAsync(targetTransform, targetTransform.position, endPos, 1, EaseType.EaseOutElastic);
            var targetRenderer = target.GetComponent<MeshRenderer>();
            var targetMaterial = targetRenderer.material;
            Tween.PlayMaterialColor(targetMaterial, shaderId, targetMaterial.color, Color.red, 1);
            Tween.PlayScale(targetTransform, targetTransform.localScale, new Vector3(2,2,2), 1, EaseType.EaseInOutElastic);
            await Tween.PlayRotateAsync(targetTransform, 0, 360, 1, EaseType.EaseInCircle);
            Tween.PlayMove(targetTransform, targetTransform.position, startPos, 1, EaseType.EaseOutBounce);
            await Awaitable.WaitForSecondsAsync(0.5f);
            Tween.PlayMaterialColor(targetMaterial, shaderId, targetMaterial.color, Color.green, 0.4f);
            await Tween.PlayScaleAsync(targetTransform, targetTransform.localScale, new Vector3(0.5f, 2, 0.5f), 0.4f, EaseType.EaseOutElastic);
            Tween.PlayMaterialColor(targetMaterial, shaderId, targetMaterial.color, Color.blue, 0.2f);
            await Tween.PlayScaleAsync(targetTransform, targetTransform.localScale, new Vector3(2f, 0.5f, 2f), 0.2f, EaseType.EaseOutElastic);
            Tween.PlayMaterialColor(targetMaterial, shaderId, targetMaterial.color, Color.white, 0.4f);
            await Tween.PlayScaleAsync(targetTransform, targetTransform.localScale, Vector3.one, 0.4f, EaseType.EaseOutElastic);
        }
    }

}
