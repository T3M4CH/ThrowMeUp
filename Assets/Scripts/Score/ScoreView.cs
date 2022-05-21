using BallController;
using UnityEngine;
namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Ball _player;
        private ScoreInteractor _scoreInteractor;
        private ScoreModel _scoreModel;
        private void Start()
        {
            _player.OnFixed += SetPosition;
            _scoreModel = new ScoreModel();
            _scoreInteractor = new ScoreInteractor(_scoreModel);
        }
        private void SetPosition()
        {
            _scoreInteractor.CommitPosition(_player.transform.position.y);
            Debug.Log(_scoreModel.Score);
        }
        private void OnDestroy()
        {
            _player.OnFixed -= SetPosition;
        }
    }
}
