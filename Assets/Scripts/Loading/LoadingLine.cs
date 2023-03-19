using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Loading
{
    public class LoadingLine : MonoBehaviour
    {
        [SerializeField]private float _startNumber = 100f;
        private float _timeMultiplier = 0f;

        [SerializeField] private TextMeshProUGUI textHp;
        
        [Header("PowerUp")]
        [SerializeField] private PowerUps _PowerUp;
        
        [Header("Image type")]
        [SerializeField] private Image _fillImage;
        
        [Header("Cooldown time")]
        [SerializeField] private float _cooldownTime;

        private bool _cooldownEnable = false;

        private void Start()
        {
            _timeMultiplier = _startNumber * _cooldownTime;
            textHp.text = _timeMultiplier.ToString();
        }

        private void Update()
        {
            _startNumber += Time.deltaTime * _timeMultiplier;
        }

        private void OnEnable()
        {
            LineInputs.onGetPowerUps += CheckPowerUpStatus;
        }

        private void CheckPowerUpStatus(PowerUps powerUpOnUse)
        {
            if (_PowerUp == powerUpOnUse)
            {
                _cooldownEnable = true;
                StartCooldown();
            }
        }

        private void StartCooldown()
        {
            _fillImage.fillAmount = 1f;

            _fillImage.DOFillAmount(0, _cooldownTime).OnComplete(() =>
            {
                _fillImage.fillAmount = 0;
            });
            
        }

        private void OnDisable()
        {
            LineInputs.onGetPowerUps -= CheckPowerUpStatus;
        }
    }
}
      