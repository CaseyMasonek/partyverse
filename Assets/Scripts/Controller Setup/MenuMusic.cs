using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip controllerSetupMusic;
    [SerializeField] private AudioClip menuMusic;

    private float _time;
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _audioSource = GetComponent<AudioSource>();
        
        _audioSource.Stop();
        
        Debug.Log(SceneManager.GetActiveScene().name);

        if (SceneManager.GetActiveScene().name == "Controller Setup")
        {
            _audioSource.clip = controllerSetupMusic;
            _audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "Title Screen")
        {
            Debug.Log(SceneManager.GetActiveScene().name +"!!!");
            
            _audioSource.clip = menuMusic;
            _audioSource.time = _time;
            _audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _time = _audioSource.time;
    }
}
