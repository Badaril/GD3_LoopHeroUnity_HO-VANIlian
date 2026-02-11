using UnityEngine;

public class SightPerception : MonoBehaviour
{
    [SerializeField] private bool isDetected;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] GameObject detectionObject;
    private Vector3 targetDirection;

    private void Update()
    {
        ActivateDetection();
    }

    public void ActivateDetection()
    {
        targetDirection = detectionObject.transform.position - transform.position;
        if (Vector3.Dot(transform.forward, Vector3.Normalize(targetDirection)) > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, targetDirection, out hit, detectionRange))
            {
                if (hit.collider.gameObject == detectionObject)
                {
                    isDetected = true;
                    return;
                }
            }
        }
        isDetected = false;
    }
}
