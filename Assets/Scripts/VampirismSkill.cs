using System.Collections;
using UnityEngine;
using System;

public class VampirismSkill : MonoBehaviour
{
    [SerializeField] float _skillRange;
    [SerializeField] LayerMask _enemyMask;
    [SerializeField] private float _skillDamage;
    [SerializeField] private float _timeSkillActive;
    [SerializeField] private float _timePeriodicSkill;
    [SerializeField, Range(0.1f, 1.0f)] private float _percentVampirism;
    [SerializeField] private float _coolDawnTimeSkillVamprism;

    private bool _isActiveSkill = false;

    public event Action<float> SkillChanged;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !_isActiveSkill)
        {
            StartCoroutine(SkillActive());
        }        
    }

    private IEnumerator SkillActive()
    {
        float currentTime = 0f;
        float currenTimeCoolDawnForBar;
        _isActiveSkill = true;

        while (currentTime <= _coolDawnTimeSkillVamprism)
        {
            if (currentTime <= _timeSkillActive)
            {
                Collider2D hitEnemy = Physics2D.OverlapCircle(transform.position, _skillRange, _enemyMask);

                if (hitEnemy)
                {
                    hitEnemy.GetComponent<Health>().TakeDamage(_skillDamage);
                    gameObject.GetComponent<Health>().Heal(_skillDamage * _percentVampirism);
                }
            }

            currentTime += _timePeriodicSkill;
            currenTimeCoolDawnForBar = currentTime / _coolDawnTimeSkillVamprism;
            SkillChanged?.Invoke(currenTimeCoolDawnForBar);
            yield return new WaitForSeconds(_timePeriodicSkill);
        }

        _isActiveSkill = false;
    }
}
