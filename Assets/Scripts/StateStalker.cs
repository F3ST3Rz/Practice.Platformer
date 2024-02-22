using System.Collections;
using UnityEngine;

public class StateStalker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedMoveStalkering;
    [SerializeField] private float _timeToStalkering;

    private bool _isStlakering;

    public bool IsStalkering => _isStlakering;

    private void OnEnable()
    {
        _isStlakering = true;
        StartCoroutine(Stalkering());
    }

    private void OnDisable()
    {
        _isStlakering = false;
    }

    private IEnumerator Stalkering()
    {
        float currentTime = 0f;
        float yOffset = 1f;

        while (currentTime <= _timeToStalkering)
        {
            if (_target == null)
                break;

            currentTime += Time.deltaTime;
            Vector3 target = _target.position + Vector3.up * yOffset;
            transform.position = Vector3.MoveTowards(transform.position,
                target, _speedMoveStalkering * Time.deltaTime);
            yield return null;
        }

        _isStlakering = false;
    }
}