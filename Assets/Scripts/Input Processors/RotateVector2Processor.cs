using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
[InitializeOnLoad]
#endif
public class RotateVector2Processor : InputProcessor<Vector2>
{
    [Tooltip("Counter-clockwise rotation in degrees")]
    public float degrees = 90f;

    public override Vector2 Process(Vector2 value, InputControl control)
    {
        float rad = degrees * Mathf.Deg2Rad;
        float c = Mathf.Cos(rad), s = Mathf.Sin(rad);
        return new Vector2(value.x * c - value.y * s,
            value.x * s + value.y * c);
    }

#if UNITY_EDITOR
    static RotateVector2Processor() => Initialize();
#endif

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize() =>
        InputSystem.RegisterProcessor<RotateVector2Processor>("RotateVector2");
}