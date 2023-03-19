using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
 private Vector3 _originalScale;
 private Vector3 _scaleTo;
 
 [SerializeField] private float _duraction = 2.0f;
 [SerializeField] private float _scaleButton = 2.0f;

 private void Start()
 {
  _originalScale = transform.localScale;
  _scaleTo = _originalScale * _scaleButton;

  transform.DOScale(_scaleTo, _duraction).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
 }
}




