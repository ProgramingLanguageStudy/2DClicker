using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    HeroUpgradeData _upgradeData;

    public float moveSpeed = 30f;         // ���� �ö󰡴� �ӵ�
    public float fadeDuration = 1f;       // ������� �� �ɸ��� �ð�

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
        // �ʱ�ȭ
        elapsed = 0f;
        text.color = startColor;
        transform.localPosition = Vector3.zero; // �θ� ���� (0, 0, 0) ��ġ
    }

    void Update()
    {
        // ���� �̵�
        transform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;

        // ���� ���� ���̱�
        elapsed += Time.deltaTime;
        float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
        text.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

        // ���� �ð� �� ��Ȱ��ȭ
        if (elapsed >= fadeDuration)
        {
            Destroy(gameObject);
        }
    }

    public void Setup(double damage, bool isCritical)
    {
        text = GetComponent<TextMeshProUGUI>();

        // �ؽ�Ʈ ����
        text.text = damage.ToClikerString(_upgradeData.SumTextFormat); // õ���� �޸� ����

        // ũ��Ƽ�� ���ο� ���� ���� �ٸ���
        if (isCritical)
            text.color = Color.red;
        else
            text.color = Color.white;

        // �ʱ�ȭ
        elapsed = 0f;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
        transform.localPosition = Vector3.zero;
    }
}
