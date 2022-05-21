using LevelScale;
using UnityEngine;
namespace BlockNamespace
{
    public class FinishBlock : Block
    {
        [SerializeField] private BoolChannel _winnerMessage;
        public override bool Palpable()
        {
            _player.OnFixed += SetWindow;
            return base.Palpable();
        }
        private void Start()
        {
            FindObjectOfType<DistanceSlider>().Initialize(transform);
        }
        private void SetWindow()
        {
            _winnerMessage.BoolInvoke(true);
        }
        private void OnDestroy()
        {
            _player.OnFixed -= SetWindow;
        }
    }
}
