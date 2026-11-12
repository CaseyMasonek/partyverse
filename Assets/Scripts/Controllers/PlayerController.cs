using UnityEngine;
using UnityEngine.InputSystem;

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
            
            if (_player is null || _player.InputActionAsset is null) return Vector2.zero;
        
            _move = _player.InputActionAsset.FindAction("Move");
            
            _isInputAssigned = true;
        }
        
        Vector2 dir = _move.ReadValue<Vector2>();
        
        return dir;
    }
}
