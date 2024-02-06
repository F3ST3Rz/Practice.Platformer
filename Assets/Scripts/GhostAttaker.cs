using UnityEngine;

public class GhostAttaker : MonoBehaviour
{
    [SerializeField] private float _attackDamage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(_attackDamage);
        }
    }
}
