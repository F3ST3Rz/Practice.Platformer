using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{
    [SerializeField] private VampirismSkill _skill;
    [SerializeField] private Image _image;

    private void OnEnable()
    {
        _skill.SkillChanged += OnChangeFillAmount;
    }

    private void OnDisable()
    {
        _skill.SkillChanged -= OnChangeFillAmount;
    }

    private void OnChangeFillAmount(float value)
    {
        _image.fillAmount = value;
    }
}
