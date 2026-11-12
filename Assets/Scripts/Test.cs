using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    private InputAction _move;
    private PlayerInput _playerInput;
    private Player _player;

    private bool _isInputAssigned;

    [SerializeField] private int playerIndex;

    private void Start()
    {
        _player = Game.players[playerIndex];
    }

    private void Update()
    {
        if (!_isInputAssigned)
        {
            if (_player is null || _player.InputActionAsset is null) return;
        
            _move = _player.InputActionAsset.FindAction("Move");
            
            _isInputAssigned = true;
        }
        
        Vector2 dir = _move.ReadValue<Vector2>();
        
        transform.Translate(dir * 3 * Time.deltaTime);
    }
}