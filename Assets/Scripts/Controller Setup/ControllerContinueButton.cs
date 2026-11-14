using UnityEngine;
using UnityEngine.UI;

public class ControllerContinueButton : MonoBehaviour
{
    private Button _button;
    private bool _activated;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    private void Update()
    {
        if (_activated) return;

        if (Game.playersIn == 4)
        {
            _button.interactable = true;
            _activated = true;
        }
    }
}
