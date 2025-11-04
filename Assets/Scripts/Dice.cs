using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _playerPawn;
    private bool _isRolling;
    [SerializeField] private TextMeshProUGUI _buttonText;

    public void RollDice()
    {
        int value = Random.Range(1, 7);
        Debug.Log($"Le dé a fait {value}");
        _playerPawn.TryMoving(value);
    }

    public void IsRolling()
    {
        int value = Random.Range(1, 7);
    }

    public void DrawDice()
    {
        StartCoroutine(SetBoolForSeconds(2f));
        RollDice();
    }

    private IEnumerator SetBoolForSeconds(float duration)
    {
        _isRolling = true;
        yield return new WaitForSeconds(duration);
        _isRolling = false;
    }

    private void Update()
    {
        while (_isRolling) 
        { 
            IsRolling();
        }
    }
}
