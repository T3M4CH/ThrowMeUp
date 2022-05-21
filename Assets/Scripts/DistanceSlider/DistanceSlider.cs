using UnityEngine.UI;
using UnityEngine;
namespace LevelScale
{
    public class DistanceSlider : MonoBehaviour
    {
        [SerializeField] private Transform _pointA;
        private Transform _pointB;
        private Slider _slider;
        private void Start()
        {
            _slider = GetComponent<Slider>();
            enabled = false;
        }
        public void Initialize(Transform pointB)
        {
            _pointB = pointB;
            _slider.maxValue = _pointB.position.y - _pointA.position.y;
            enabled = true;
        }
        private void Update()
        {
            _slider.value = _pointA.position.y;
        }
    }
}