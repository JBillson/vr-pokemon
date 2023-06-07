using UnityEngine;

namespace Utilities
{
    public class Billboard : MonoBehaviour
    {
        public bool disabled;
        public bool reversed;
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (disabled) return;
            
            var activeTransform = transform;
            activeTransform.LookAt(_mainCamera.transform);
            var eulerRotation = activeTransform.localRotation.eulerAngles;
            var localRotation = reversed
                ? Quaternion.Euler(0, eulerRotation.y, 0)
                : Quaternion.Euler(0, eulerRotation.y + 180, 0);
            activeTransform.localRotation = localRotation;
        }
    }
}