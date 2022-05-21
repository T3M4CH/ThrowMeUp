using UnityEngine;

public class GapingPit : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private BoolChannel _messageChannel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _messageChannel.BoolInvoke(false);
        }
    }
}
