using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    private const string Damage = nameof(Damage);

    [SerializeField] private Animator _animator;
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public event Action<float> LifeChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _animator.SetTrigger(Damage);
        _currentHealth -= damage;
        float currentHealthForBar = _currentHealth / _maxHealth;
        LifeChanged?.Invoke(currentHealthForBar);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void Heal(float countHeal)
    {
        _currentHealth += countHeal;
        _currentHealth = _currentHealth > _maxHealth ? _maxHealth : _currentHealth;
        float currentHealthForBar = _currentHealth / _maxHealth;
        LifeChanged?.Invoke(currentHealthForBar);
    }
}
