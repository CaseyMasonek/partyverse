using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicUIFunctions : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToSceneWithSFX(string sceneName)
    {
        StartCoroutine(PlaySfxAndSwitchScene(sceneName));
    }

    private IEnumerator PlaySfxAndSwitchScene(string sceneName)
    {
        _audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
    
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
