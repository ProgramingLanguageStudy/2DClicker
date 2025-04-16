using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroUpgradeView : MonoBehaviour
{
    [Header("----- 컴포넌트 참조 -----")]
    // 업그레이드 항목 이름 표시 TMP 컴포넌트
    [SerializeField] TextMeshProUGUI _StatNameText;
    // 업그레이드 레벨 표시 TMP 컴포넌트
    [SerializeField] TextMeshProUGUI _StatLvText;
    // 능력치 표시 TMP 컴포넌트
    [SerializeField] TextMeshProUGUI _StatInfoText;
    // 이번 업그레이드 비용 TMP 컴포넌트
    [SerializeField] TextMeshProUGUI _UpgradeCostText;
    // 이번 업그레이드로 올라갈 수치 표시 TMP 컴포넌트
    [SerializeField] TextMeshProUGUI _UpgradeValueText;

    HeroUpgradeData _upgradeData;
    int _currentLevel = 1; // ⭐ 시작 레벨
    public void Initialize(HeroUpgradeData upgradeData)
    {
        _upgradeData = upgradeData;
        RefreshUI(_currentLevel);
    }

    public void Upgrade()
    {
        _currentLevel++;               // ⭐ 레벨업
        RefreshUI(_currentLevel);      // UI 갱신
    }

    public void RefreshUI(int level)
    {
        _StatNameText.text = _upgradeData.UpgradeName;
        _StatLvText.text = $"LV.{level}";
        _StatInfoText.text = string.Format(_upgradeData.SumTextFormat, _upgradeData.GetValueByLevel(level));
        _UpgradeCostText.text = _upgradeData.GetCostByLevel(level).ToString("F0");
        _UpgradeValueText.text = string.Format(_upgradeData.ValueTextFormat, _upgradeData.GetValueByLevel(level + 1));
    }
}
