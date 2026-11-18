using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Character character;
    
    private Button _button;
    private Image _image;
    private AudioSource _audioSource;
    
    private VirtualMouseInput[] _mice;
    
    private void Start()
    {
        _mice = FindObjectsByType<VirtualMouseInput>();
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_button.interactable) return;
        
        Debug.Log(eventData.pointerId);
        
        VirtualMouseInput mouse = GetVirtualMouse(eventData.pointerId);
        int playerIndex = mouse.GetComponent<PlayerController>().playerIndex;
        
        Game.players[playerIndex].Character = character;

        _button.interactable = false;
        _image.color = mouse.gameObject.GetComponent<Image>().color;
        mouse.enabled = false;
        
        _audioSource.Play();

        Game.charchtersSelected++;
    }
    
    private VirtualMouseInput GetVirtualMouse(int pointerId)
    {
        foreach (VirtualMouseInput mouse in _mice)
        {
            if (mouse.virtualMouse is not null && mouse.virtualMouse.deviceId == pointerId)
            {
                return mouse;
            }
        }

        return null;
    }
}
