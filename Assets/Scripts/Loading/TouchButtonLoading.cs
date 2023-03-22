using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchButtonLoading : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
 private Vector3 _originalScale;
 private Vector3 _scaleTo;

 [SerializeField] private float _duraction = 2.0f;
 [SerializeField] private float _scaleButton = 2.0f;
 [SerializeField] private Ease _ease = Ease.InOutSine;
 private TweenerCore<Vector3, Vector3, VectorOptions> tweener;

 private void Start()
 {
  _originalScale = transform.localScale;
  _scaleTo = _originalScale * _scaleButton;
 }

 public void OnPointerEnter(PointerEventData eventData)
 {
 tweener = transform.DOScale(_scaleTo, _duraction).SetEase(_ease);
 }

 public void OnPointerExit(PointerEventData eventData)
 {
 tweener = transform.DOScale(_scaleTo, _duraction).SetEase(_ease);
 }
// атрибут
 [ContextMenu("Stop animation")]
 public void Stop()
 {
  tweener.Pause();
 }
 
 [ContextMenu("Play animation")]
 public void Play()
 {
  tweener.Play();
 }
}