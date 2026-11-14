using UnityEngine;

public class InitializeGame : MonoBehaviour
{
    private void Awake()
    {
        Game.playersIn = 0;
        Game.players = new Player[4];
        Game.players[0] = new Player();
        Game.players[1] = new Player();
        Game.players[2] = new Player();
        Game.players[3] = new Player();
    }
}
