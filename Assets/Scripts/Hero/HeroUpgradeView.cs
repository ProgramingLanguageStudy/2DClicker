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
    public void Initialize(HeroUpgradeData upgradeData)
    {
        _upgradeData = upgradeData;
    }

    

    
}
