using UnityEngine;
using UnityEngine.EventSystems;




public class Button : MonoBehaviour
{
 private Vector3 _originalScale;
 private Vector3 _scaleTo;
 
 [SerializeField] private float _duraction = 2.0f;
 [SerializeField] private float _scaleButton = 2.0f;
 
 public void OnPointerEnter(PointerEventData eventData)
 {
  transform.localScale = new Vector2(1.5f, 1.5f);
 }

 public void OnPointerExit(PointerEventData eventData)
 {
  transform.localScale = new Vector3(1, 1, 1);
 }
}




