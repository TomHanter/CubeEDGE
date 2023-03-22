using Cysharp.Threading.Tasks;
using DG.Tweening;
using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoinAnimationManager : SingletonMonoBehaviour<CoinAnimationManager>
    {
        [SerializeField] private AnimaterdScoreDispaly _scoreDispaly;
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private float _animationDuration = 1f;
        [SerializeField] private float _spread = 50f;
        
        public void Animate(int amout, Vector3 startPosition)
        {
            var coinAmout = amout / 10;
            
            for (int i = 0; i < coinAmout; i++)
            {
                CreateCoinAtRandomPosition(startPosition);
            }
        }

        private void CreateCoinAtRandomPosition(Vector3 startPosition)
        {
            var coin = Instantiate(_coinPrefab, _canvas.transform);

            var startScreenPosition = Camera.main.WorldToScreenPoint(startPosition);
            var targetScreenPosition = _scoreDispaly.transform.position;

            startPosition += new Vector3(
                Random.Range(-_spread, _spread),
                Random.Range(-_spread, _spread));
            
            coin.transform.position = startPosition;

            coin.transform.localScale = Vector3.zero;
            
            // 1 последовательность анимаций через стрелоч функцию (лямбда функция)
            // coin.transform.DOScale(Vector3.one, _animationDuration).OnComplete(
            //     () => coin.transform.DOMove(targetScreenPosition, _animationDuration)
            //         .OnComplete(() => Destroy(coin.gameObject)));
            
            // 2 через Sequnce
             var sequnce = DOTween.Sequence();
             sequnce.Append(coin.transform.DOScale(Vector3.one, _animationDuration));
             sequnce.Append(coin.transform.DOMove(targetScreenPosition, _animationDuration));
             sequnce.OnComplete(() => Destroy(coin.gameObject));
            
            // 3 самодельная анимация
            // AnimateTask(coin.transform, targetScreenPosition, _animationDuration);
        }


        /*private async void AnimateTask(Transform animatedTransform, Vector3 endPos, float animationDuration)
        {
            var startPos = animatedTransform.position;
            var step = 1f / animationDuration;
                
            // идем от 0 до 1 на протяжении "animationDur" секунд    
            for (float t = 0f; t <=1f; t += step * Time.deltaTime)
            {
               var middlePosition = Vector3.Lerp(startPos, endPos, 0f);
               animatedTransform.position = middlePosition;
               
                await UniTask.WaitForFixedUpdate();
            }

        }*/
    }
}