using UnityEngine;
using UnityEngine.InputSystem;

public class AssignInput : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Player _player;
    
    private void Start()
    {
        _player = Game.players[Game.playersIn];

        Game.playersIn++;
        
        _playerInput = GetComponent<PlayerInput>();
        
        Debug.Log(Game.players[0]);
        
        _player.InputActionAsset = _playerInput.actions;
        
        Destroy(this);
    }
}
