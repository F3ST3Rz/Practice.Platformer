using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Health _health;
    [SerializeField] private float _transitionSpeed;

    private float _targetFillAmount = 1.0f;
    private Coroutine _changeFillAmount;

    private void OnEnable()
    {
        _health.LifeChanged += OnChangeHealth;
    }

    private void OnDisable()
    {
        _health.LifeChanged -= OnChangeHealth;
    }

    private void OnChangeHealth(float value)
    {
        _targetFillAmount = value;

        if (_changeFillAmount != null)
            StopCoroutine(_changeFillAmount);

        _changeFillAmount = StartCoroutine(ChangeFillAmount());
    }

    private IEnumerator ChangeFillAmount()
    {
        float currentFillAmount = _image.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < _transitionSpeed)
        {
            _image.fillAmount = Mathf.Lerp(currentFillAmount, _targetFillAmount, elapsedTime / _transitionSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _image.fillAmount = _targetFillAmount;
        _changeFillAmount = null;
    }
}
