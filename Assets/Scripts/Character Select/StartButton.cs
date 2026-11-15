using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject _startButton;
    
    private AudioSource _audioSource;

    private bool _isReady;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Game.charchtersSelected < 4) return;
        
        _startButton.SetActive(true);
        
        _isReady = true;
        
        EventSystem.current.SetSelectedGameObject(_startButton);
    }

    public void StartButtonPressed()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        Camera.main!.backgroundColor = Color.gray6;
        _audioSource.Play();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("SampleScene");
    }
}
