using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private Color _normalColor = Color.white;
    [SerializeField] private Color _criticalColor = Color.red;
    [SerializeField] private float _floatSpeed = 1f;
    [SerializeField] private float _destroyDelay = 1f;
    [SerializeField] private Vector3 _floatOffset = new Vector3(0, 1f, 0);

    private Vector3 _startPos;

    public void Setup(double damage, bool isCritical)
    {
        _damageText.text = damage.ToString("F0");
        _damageText.color = isCritical ? _criticalColor : _normalColor;
        _damageText.fontSize = isCritical ? 36 : 24;

        _startPos = transform.position;
        StartCoroutine(FloatAndFade());
    }

    private IEnumerator FloatAndFade()
    {
        float elapsed = 0f;

        while (elapsed < _destroyDelay)
        {
            float t = elapsed / _destroyDelay;
            transform.position = _startPos + _floatOffset * t;

            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
