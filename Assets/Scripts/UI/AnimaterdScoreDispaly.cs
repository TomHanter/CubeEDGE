using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class AnimaterdScoreDispaly : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private float _maxAnimationDuration = 2f;
        [SerializeField] private float _delayBetweenNumbers = 0.02f;

        [ContextMenu("Text")]
        public void Test()
        {
            var startAmout = 100;
            var targetAmout = 1500;
            
            Animate(startAmout, targetAmout);
        }

        public void Set(int value)
        {
            _countText.text = value.ToString();
        }
        
        public void Animate(int from, int to)
        {
            _countText.text = from.ToString();

            StartCoroutine(AnimateCoroutine(from, to));
        }

        private IEnumerator AnimateCoroutine(int from, int to)
        {
            var range = to - from;
            var duration = range / _delayBetweenNumbers;
            duration = Mathf.Min(_maxAnimationDuration, duration);
            var delay = duration / range;
            
            for (int i = from; i <= to; i++)
            {
                _countText.text = i.ToString();
                yield return new WaitForSeconds(delay);
            }
        }
    }
}