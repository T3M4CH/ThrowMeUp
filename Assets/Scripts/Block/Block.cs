using UnityEngine;
using BallController;
namespace BlockNamespace
{
    public class Block : MonoBehaviour, IBlock
    {
        [SerializeField] private bool _palpable;
        protected Ball _player;
        public void Initialize(Ball player)
        {
            _player = player;
        }
        public virtual bool Palpable()
        {
            return _palpable;
        }
    }
}