using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Switch;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public static class SwitchProLayoutFix
{
    static bool registered;

    static SwitchProLayoutFix()
    {
        Register();
    }

    [RuntimeInitializeOnLoadMethod(
        RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void RegisterAtRuntime()
    {
        Register();
    }

    static void Register()
    {
        if (registered) return;
        registered = true;

        InputSystem.RegisterLayoutMatcher<SwitchProControllerHID>(
            new InputDeviceMatcher()
                .WithInterface("HID")
                .WithProduct("Lic Pro Controller")
        );
    }
}