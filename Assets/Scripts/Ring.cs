using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private QuestManager _questManager;
    [SerializeField] private GameObject ring;

    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime * 2, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _questManager._isQuestFinished = true;
            ring.SetActive(false);
        }
    }

}
