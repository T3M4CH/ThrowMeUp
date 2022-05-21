using UnityEngine;
using UnityEngine.EventSystems;

namespace BallController
{
    internal class TouchScript : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private Canvas _canvas;
        private bool _dragging;
        public void OnBeginDrag(PointerEventData eventData)
        {
            _ball.BeginStretching();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _dragging = true;
            _ball.Stretch(eventData.delta.y / (_canvas.scaleFactor * 175));
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _dragging = false;
            _ball.AddForce();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if(!_dragging)
            _ball.TryCatch();
        }
    }
}
