using UnityEngine.UI;
using UnityEngine;
using TMPro;
namespace UI
{
    public class MessagePanel : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI Text;
        [field: SerializeField] public TextMeshProUGUI ButtonText;
        [SerializeField] private BoolChannel _onPlayerFinish;
        private MessageScript _messageScript;
        private void Start()
        {
            _messageScript = new MessageScript(_onPlayerFinish, this);
        }
        private void OnDestroy()
        {
            _messageScript.Dispose();
        }
    }
}
