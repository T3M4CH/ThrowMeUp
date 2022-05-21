using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float speed = 5;
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(transform.position.x, Mathf.Max(_target.position.y, 1), transform.position.z), Time.fixedDeltaTime * speed);
    }
}