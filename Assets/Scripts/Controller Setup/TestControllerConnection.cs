using TMPro;
using UnityEngine;

public class TestControllerConnection : MonoBehaviour
{
    [SerializeField] private int playerIndex;

    private TMP_Text _text;
    private Player _player;
    
    private bool _connected;
    
    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        
        _player = Game.players[playerIndex];
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_connected)
        {
            if (_player.Actions is null) return;
            
            _connected = true;
            
            _text.text = "P" + (playerIndex + 1) + " - Connected";
        }
    }
}
