using UnityEngine;
using Scene;
using TMPro;
namespace LevelScale
{
    public class SliderLevelDisplay : MonoBehaviour
    {
        [SerializeField] private SceneView _sceneView;
        [SerializeField] private TextMeshProUGUI _currentLevel;
        [SerializeField] private TextMeshProUGUI _nextLevel;
        private void Awake()
        {
            _sceneView.OnSetLevel += SetTextes;
        }
        private void SetTextes(int currentLevel)
        {
            _currentLevel.text = currentLevel.ToString();
            _nextLevel.text = (currentLevel + 1).ToString();
        }
    }
}

