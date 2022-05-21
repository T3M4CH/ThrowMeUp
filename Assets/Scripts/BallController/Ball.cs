using System;
using UnityEngine;
using BlockNamespace;
namespace BallController
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        private float _yPos;
        private Rigidbody _rigidbody;
        public event Action OnFixed;
        public event Action OnTouched;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void BeginStretching()
        {
            _yPos = transform.position.y;
        }
        public void Stretch(float force)
        {
            if (!_rigidbody.isKinematic) return;
            transform.position -= Vector3.down * force;
            transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, _yPos - 0.5f, _yPos), -1);
        }
        public void AddForce()
        {
            if (!_rigidbody.isKinematic) return;
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * JumpForce(_yPos, transform.position.y), ForceMode.Impulse);
        }
        private float JumpForce(float a, float b) => (-b + a) * 20;
        public void TryCatch()
        {
            if (_rigidbody.isKinematic) return;
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.transform.TryGetComponent(out IBlock block))
                {
                    Catch(block.Palpable());
                }
            }
        }
        private void Catch(bool palpable)
        {
            if (!palpable)
            {
                OnTouched?.Invoke();
                return;
            }
            if (palpable)
            {
                _rigidbody.isKinematic = true;
                _rigidbody.velocity = Vector3.zero;
                _yPos = transform.position.y;
                OnFixed?.Invoke();
            }

        }
    }
}