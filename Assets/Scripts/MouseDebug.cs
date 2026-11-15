using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;

public class PointerDebug : MonoBehaviour
{
    public EventSystem eventSystem;

    void Update()
    {
        foreach (var mouse in InputSystem.devices)
        {
            if (mouse is not Mouse m)
                continue;

            if (m.leftButton.wasPressedThisFrame)
            {
                Debug.Log(
                    $"CLICK: {m.name}, ID: {m.deviceId}, " +
                    $"Position: {m.position.ReadValue()}"
                );
            }
        }
    }
}