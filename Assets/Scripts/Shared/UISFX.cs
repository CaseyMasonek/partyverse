using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISFX : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private bool _wasHighlighted = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject && !_wasHighlighted)
        {
            _audioSource.Play();
            
            _wasHighlighted = true;
        }

        if (_wasHighlighted && EventSystem.current.currentSelectedGameObject != gameObject)
        {
            _wasHighlighted = false;
        }
    }
}
