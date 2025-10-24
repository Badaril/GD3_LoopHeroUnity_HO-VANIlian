using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _playerPawn;
    private bool _isRolling;
    [SerializeField] private Text _buttonText;

    public void RollDice()
    {
        int value = Random.Range(1, 7);
        Debug.Log($"Le dé a fait {value}");
        //_playerPawn.TryMoving(value);
    }

    public void Rolling()
    {
        RollDice();
    }

    private void Update()
    {
        while (_isRolling) 
        { 
            Rolling();
        }
    }
}
