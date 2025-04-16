using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 주인공 캐릭터의 업그레이드를 해 주는 역할
public class HeroUpgrader : MonoBehaviour
{
    [Header("----- 업그레이드 데이터 -----")]
    // 주인공 캐릭터 업그레이드 데이터 배열
    [SerializeField] HeroUpgradeData[] _upgradeDatas;

    [Header("----- 컴포넌트 참조 -----")]
    [SerializeField] HeroStatus _status;
    [SerializeField] HeroUpgradeView[] _upgradeViews;

    // 임시
    [SerializeField] int[] _upgradeLevels;

    public void Initialize()
    {
        _upgradeLevels = new int[_upgradeDatas.Length];

        for (int i = 0; i < _upgradeDatas.Length; i++)
        {
            _upgradeViews[i].Initialize(_upgradeDatas[i]);
            _upgradeViews[i].RefreshUI(_upgradeLevels[i]);
        }
    }

    public void Upgrade(int statIndex)
    {
        if (statIndex < 0 || statIndex >= _upgradeDatas.Length)
            return;

        Upgrade((HeroStatType)statIndex);
    }

    public void Upgrade(HeroStatType statType)
    {
        // statType을 int로 변환
        int statIndex = (int)statType;

        // 업그레이드 레벨 증가
        _upgradeLevels[statIndex]++;
        int level = _upgradeLevels[statIndex];

        // 업그레이드 데이터 가져오기
        HeroUpgradeData upgradeData = _upgradeDatas[statIndex];

        // 업그레이드 수치 적용하기
        double value = upgradeData.GetValueByLevel(level);
        _status.AddStat(statType, value);

        _upgradeViews[statIndex].RefreshUI(level);
    }
}
