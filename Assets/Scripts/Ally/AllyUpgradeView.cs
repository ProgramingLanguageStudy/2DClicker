using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 동료 캐릭터 구매/업그레이드 UI 담당하는 역할
public class AllyUpgradeView : MonoBehaviour
{
    const string _levelTextFormat = "Lv. {0}";
    const string _sumTextFormat = "데미지: {0:N2}";
    const string _costTextFormat = "{0:N0}";
    const string _valueTextFormat = "+ {0:N2} DPS";

    AllyData _data;
    AllyController _controller;

    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] TextMeshProUGUI _sumText;
    [SerializeField] TextMeshProUGUI _costText;
    [SerializeField] TextMeshProUGUI _valueText;
    [SerializeField] Image _iconSprite;

    public void Initialize(AllyData data, AllyController controller)
    {
        _data = data;
        _controller = controller;

        _nameText.text = _data.AllyName;
        _iconSprite.sprite = _data.IconSprite;

        UpdateView(0, 0);
    }

    public void UpdateView(int level, double sum)
    {
        _levelText.text = string.Format(_levelTextFormat, level);

        _sumText.text = sum.ToClikerString(_sumTextFormat);

        double cost = _data.GetCostByLevel(level);
        _costText.text = cost.ToClikerString(_costTextFormat);

        double value = _data.GetDamageByLevel(level + 1);
        _valueText.text = value.ToClikerString(_valueTextFormat);
    }

    /// <summary>
    /// 업그레이드 버튼이 눌렸을 때 실행되는 함수
    /// </summary>
    public void OnUpgradeButtonClicked()
    {
        // 업그레이드 처리
        _controller.Upgrade(_data.AllyType);
    }
}
