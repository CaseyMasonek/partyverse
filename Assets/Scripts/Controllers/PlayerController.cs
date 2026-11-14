using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour, IMovementController
{
    private InputAction _move;
    private PlayerInput _playerInput;
    private Player _player;

    private bool _isInputAssigned;

    public Vector2 GetMovement(int playerIndex)
    {
        if (!_isInputAssigned)
        {
            _player = Game.players[playerIndex];
            
            if (_player is null || _player.Actions is null) return Vector2.zero;
            
            _player.Actions.devices = new [] { _player.Device };
            
            _move = _player.Actions.FindAction("Move");
            _move.Enable();
            
            _isInputAssigned = true;
        }
        
        Vector2 dir = _move.ReadValue<Vector2>();
        
        Debug.DrawLine(Vector2.zero,transform.position, Color.yellow);
        
        return dir;
    }

    private void OnDestroy()
    {
        _move.Disable();
    }
}
