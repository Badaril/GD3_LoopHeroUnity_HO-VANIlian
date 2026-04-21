using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Récupère les inputs
        float horizontal = Input.GetAxis("Horizontal"); // Q/D ou ←/→
        float vertical = Input.GetAxis("Vertical");     // Z/S ou ↑/↓

        // Déplacement
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + movement);
    }
}
