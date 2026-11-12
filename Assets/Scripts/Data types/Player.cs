using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player")]
public class Player : ScriptableObject
{
    public Character character;
    public int score;
}
