using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Minigame", menuName = "Scriptable Objects/Minigame")]
public class Minigame : ScriptableObject
{
    public string name;
    public string gameScene;
    public string tutorialScene;
    
    public void LoadGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    
    public void LoadTutorial()
    {
        SceneManager.LoadScene(tutorialScene);
    }
}
