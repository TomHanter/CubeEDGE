using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace.Inputs
{
    public class JoystickTouchZone : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private Image _joystickBackground;
        [SerializeField] private Image _joystickHandle;

        private Vector2 _currentDirection;
        
        public Vector2 CurrentDirection => _currentDirection;
        
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            ShowControls();
            SetBackgroundPosition(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            FollowMouse(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            HideControls();
            _currentDirection = Vector2.zero;
        }

        private void HideControls()
        {
            _joystickBackground.enabled = false;
            _joystickHandle.enabled = false;
        }

        private void ShowControls()
        {
            _joystickBackground.enabled = true;
            _joystickHandle.enabled = true;
        }

        private void SetBackgroundPosition(PointerEventData eventData)
        {
            _joystickBackground.transform.position = eventData.position;
        }

        private void FollowMouse(PointerEventData pointerEventData)
        {
            var basePosition = _joystickBackground.transform.position;
            
            var radius = _joystickBackground.rectTransform.rect.height / 2f;
            
            var direction = pointerEventData.position - (Vector2)basePosition;
            
            var localPosition = Vector2.ClampMagnitude(direction, radius);
            
            _joystickHandle.transform.position = (Vector2)basePosition + localPosition;

            _currentDirection = Vector2.ClampMagnitude(localPosition / radius, 1f);
        }

    }
}
