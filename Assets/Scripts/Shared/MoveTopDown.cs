using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
public class MoveTopDown : MonoBehaviour
{
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }
    
    private void Update()
    {
        Vector2 dir = _playerController.GetMovement();
        
        transform.Translate(dir * 3 * Time.deltaTime);
    }
}