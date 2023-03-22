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
            coin.transform.DOScale(Vector3.one, _animationDuration).OnComplete(
                () => coin.transform.DOMove(targetScreenPosition, _animationDuration)
                    .OnComplete(() => Destroy(coin.gameObject)));

        }


        // private async void AnimateTask(Transform animatedTransform, Vector3 startPos, Vector3 endPos)
        // {
        //     var direction = startPos - endPos;
        //     var step = _animationDuration / direction;
        // }
    }
}