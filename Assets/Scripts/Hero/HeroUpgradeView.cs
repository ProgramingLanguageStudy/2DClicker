using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


// 주인공 업그레이드 항목 UI들을 갱신해 주는 역할
public class HeroUpgradeView : MonoBehaviour
{
    // 어떤 설정 데이터를 상수형으로 저장하는 방식
    const string _statLvTextFormat = "Lv. {0}";
    const string _upgradeCostFormat = "{0:N0}";

    [Header("----- 컴포넌트 참조 -----")]
    // 업그레이드 항목 이름 표시 TMP 컴포넌트
    [SerializeField] TextMeshProUGUI _statNameText;
    // 업그레이드 레벨 표시 TMP 컴포넌트
    [SerializeField] TextMeshProUGUI _statLvText;
    // 능력치 표시 TMP 컴포넌트
    [SerializeField] TextMeshProUGUI _statValueText;
    // 이번 업그레이드 비용 TMP 컴포넌트
    [SerializeField] TextMeshProUGUI _upgradeCostText;
    // 이번 업그레이드로 올라갈 수치 표시 TMP 컴포넌트
    [SerializeField] TextMeshProUGUI _upgradeValueText;

    [SerializeField] Image _iconSprite;

    HeroUpgradeData _upgradeData;
    
    public void Initialize(HeroUpgradeData upgradeData)
    {
        _upgradeData = upgradeData;

        _statNameText.text = _upgradeData.UpgradeName;
        
    }

    public void Upgrade()
    {
                      // ⭐ 레벨업
        
    }

    /// <summary>
    /// 주인공 캐릭터 업그레이드 정보를 UI에 표시해 주는 함수
    /// </summary>
    /// <param name="level"></param>
    /// <param name="sum"></param>
    public void UpdateView(int level, double sum)
    {
        //_statLvText.text = $"LV. " + level;
        //_statLvText.text = $"Lv. {level}";
        //_statLvText.text = string.Format("Lv. {0}", level);

        // 항목 이름 갱신
        _statLvText.text = string.Format(_statLvTextFormat, level);
        // 항목 아이콘 갱신
        _iconSprite.sprite = _upgradeData.IconSprite;

        // 지금까지 업그레이드 능력치 총합을 TMP에 표시
        //_statValueText.text = string.Format("대미지: {0:N2}", sum);
        _statValueText.text = string.Format(_upgradeData.ValueTextFormat, sum);

        // 이번 업그레이드에 필요한 골드 비용을 TMP에 표시
        double cost = _upgradeData.GetCostByLevel(level);
        _upgradeCostText.text = string.Format(_upgradeCostFormat, cost);

        // 이번 업그레이드로 증가될 수치를 TMP에 표시
        _upgradeValueText.text = string.Format(_upgradeData.ValueTextFormat, _upgradeData.GetValueByLevel(level + 1));
    }
}
