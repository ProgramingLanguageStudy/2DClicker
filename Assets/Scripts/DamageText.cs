using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    HeroUpgradeData _upgradeData;

    public float moveSpeed = 30f;         // 위로 올라가는 속도
    public float fadeDuration = 1f;       // 사라지는 데 걸리는 시간

    private TextMeshProUGUI text;
    private Color startColor;
    private float elapsed;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        startColor = text.color;
    }

    private void OnEnable()
    {
        // 초기화
        elapsed = 0f;
        text.color = startColor;
        transform.localPosition = Vector3.zero; // 부모 기준 (0, 0, 0) 위치
    }

    void Update()
    {
        // 위로 이동
        transform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;

        // 투명도 점점 줄이기
        elapsed += Time.deltaTime;
        float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
        text.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

        // 일정 시간 후 비활성화
        if (elapsed >= fadeDuration)
        {
            Destroy(gameObject);
        }
    }

    public void Setup(double damage, bool isCritical)
    {
        text = GetComponent<TextMeshProUGUI>();

        // 텍스트 설정
        text.text = damage.ToClikerString(_upgradeData.SumTextFormat); // 천단위 콤마 포함

        // 크리티컬 여부에 따라 색상 다르게
        if (isCritical)
            text.color = Color.red;
        else
            text.color = Color.white;

        // 초기화
        elapsed = 0f;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
        transform.localPosition = Vector3.zero;
    }
}
