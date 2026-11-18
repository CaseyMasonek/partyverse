using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

[RequireComponent(typeof(PlayerController))]
public class Cursor : MonoBehaviour
{
    private VirtualMouseInput _input;
    private PlayerController _playerController;
    private InputActionAsset _inputActions;
    
    private InputAction _moveAction;
    private InputAction _pressAction;
    
    private void Start()
    {
        _input = GetComponent<VirtualMouseInput>();
        _playerController = GetComponent<PlayerController>();
        _inputActions = _playerController.GetInputActions();

        _moveAction = _inputActions.FindAction("Move");
        _pressAction = _inputActions.FindAction("Click");
        
        _input.stickAction = new InputActionProperty(_moveAction);
        _input.leftButtonAction = new InputActionProperty(_pressAction);
    }
}
