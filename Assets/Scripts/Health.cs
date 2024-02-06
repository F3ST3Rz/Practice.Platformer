using UnityEngine;

public class Health : MonoBehaviour
{
    private const string Damage = nameof(Damage);

    [SerializeField] private Animator _animator;
    [SerializeField] private float _maxHealth;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Heal heal))
        {
            Heal(heal.AmountTreatment);
            Destroy(heal.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        _animator.SetTrigger(Damage);
        _health -= damage;

        if (_health <= 0)
            Destroy(gameObject);
    }

    private void Heal(float countHeal)
    {
        _health += countHeal;
        _health = _health > _maxHealth ? _maxHealth : _health;
    }
}
