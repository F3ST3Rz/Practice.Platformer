using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    private const string Attack = nameof(Attack);

    [SerializeField] private Animator _animator;
    [SerializeField] Transform _attackPoint;
    [SerializeField] float _attackRange;
    [SerializeField] LayerMask _enemyMask;
    [SerializeField] private float _attackDamage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attacking();
    }

    private void Attacking()
    {
        _animator.SetTrigger(Attack);
        Collider2D hitEnemy = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _enemyMask);

        if (hitEnemy)
            hitEnemy.GetComponent<Health>().TakeDamage(_attackDamage);
    }
}
