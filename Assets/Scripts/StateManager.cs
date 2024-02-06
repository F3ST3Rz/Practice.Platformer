using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private StatePatruler _patruler;
    [SerializeField] private StateStalker _stalker;

    private void Start()
    {
        _stalker.enabled = false;
        _patruler.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _patruler.enabled = false;
            _stalker.enabled = true;
        }
    }

    private void Update()
    {
        if (!_stalker.enabled || _stalker.IsStalkering)
            return;

        if (!_stalker.IsStalkering)
        {
            _patruler.enabled = true;
            _stalker.enabled = false;
        }
    }
}
