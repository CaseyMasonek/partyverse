using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    private InputAction _move;
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        
        _move = _playerInput.actions.FindAction("Move");
    }

    private void Update()
    {
        Vector2 dir = _move.ReadValue<Vector2>();
        
        transform.Translate(dir * 3 * Time.deltaTime);
    }
}