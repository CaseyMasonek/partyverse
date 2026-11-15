using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour, IMovementController
{
    private InputAction _move;
    private InputAction _click;

    private Player _player;
    private bool _isInputAssigned;
    
    
    private void SetupInput(int playerIndex)
    {
        _player = Game.players[playerIndex];

        if (_player is null || _player.Actions is null) return;
        
        _player.Actions.devices = new [] { _player.Device };
            
        _move = _player.Actions.FindAction("Move");
        _move.Enable();
        
        _click = _player.Actions.FindAction("Click");
        _click.Enable();
            
        _isInputAssigned = true;
        
    }

    public Vector2 GetMovement(int playerIndex)
    {
        if (!_isInputAssigned) SetupInput(playerIndex);
        
        if (_player is null || _player.Actions is null) return Vector2.zero;
        
        Vector2 dir = _move.ReadValue<Vector2>();
        
        return dir;
    }

    private void OnDestroy()
    {
        _move.Disable();
        _click.Disable();
    }

    public InputActionAsset GetInputActions(int playerIndex)
    {
        if (!_isInputAssigned) SetupInput(playerIndex);
        return _player.Actions;
    }
}
