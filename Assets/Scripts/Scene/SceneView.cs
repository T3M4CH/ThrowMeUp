using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Scene 
{
    public class SceneView : MonoBehaviour
    {
        [SerializeField] private BoolChannel playerFinish;
        [SerializeField] private Button _levelButton;
        private SceneInteractor _sceneInteractor;
        private SceneModel _sceneModel;
        public event Action<int> OnSetLevel;
        private void Start()
        {
            _sceneModel = new SceneModel();
            _sceneModel.Initialize();
            _sceneInteractor = new SceneInteractor(_sceneModel);
            playerFinish.AddListener(SetButtonAssignment);
            OnSetLevel?.Invoke(_sceneInteractor.LevelId);
        }
        private void SetButtonAssignment(bool isWinner)
        {
            if (isWinner)
            {
                _levelButton.onClick.AddListener(OnPlayerWin);
            }
            else
            {
                _levelButton.onClick.AddListener(OnPlayerLose);
            }
        }
        private void OnPlayerWin()
        {
            _sceneInteractor.AddLevel();
            SceneManager.LoadScene(0);
        }
        private void OnPlayerLose()
        {
            SceneManager.LoadScene(0);
        }
        private void OnDestroy()
        {
            _levelButton.onClick.RemoveAllListeners();
        }
    }
}
