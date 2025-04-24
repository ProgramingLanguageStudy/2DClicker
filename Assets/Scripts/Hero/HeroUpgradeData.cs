using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 스크립터블 오브젝트는 우리가 어떤 데이터들을 유니티의 에셋 파일 형태로
// 사용할 수 있도록 도와주는 기능
[CreateAssetMenu(menuName = "GameSettings/Hero/UpgradeData", fileName = "HeroUpgradeData")]
public class HeroUpgradeData : ScriptableObject
{
    // 주인공 캐릭터 업그레이드와 관련된 설정 데이터들을 보유하고 있는 역할

    [SerializeField] HeroStatType _statType;        // 스탯 종류
    [SerializeField] string _upgradeName;           // 업그레이드 항목 이름
    [SerializeField] double _baseValue;             // 업그레이드 수치 시작 값
    [SerializeField] double _baseCost;              // 업그레이드 비용 시작 값
    [SerializeField] double _valueMultiplier;       // 업그레이드 수치 계수
    [SerializeField] double _costMultiplier;        // 업그레이드 비용 계수

    [SerializeField] string _sumTextFormat;         // 수치 합계 텍스트 표시 형식
    [SerializeField] string _valueTextFormat;       // 업그레이드 수치 텍스트 표시 형식

    [SerializeField] Sprite _iconSprite;

    //public HeroStatType StatType
    //{
    //    get { return _statType; }
    //}
    public HeroStatType StatType => _statType;
    public string UpgradeName => _upgradeName;
    public string SumTextFormat => _sumTextFormat;
    public string ValueTextFormat => _valueTextFormat;
    public Sprite IconSprite => _iconSprite;

    /// <summary>
    /// 업그레이드 레벨에 따른 업그레이드 수치를 반환해 주는 함수
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public double GetValueByLevel(int level)
    {
        if (level <= 0)
        {
            return 0;
        }

        // System.Math.Pow(x, y): x를 y번 제곱한 값을 되돌려 주는 함수
        // ex. System.Math.Pow(5, 3): 5^3 = 125;
        return _baseValue * System.Math.Pow(_valueMultiplier, level - 1);
    }

    /// <summary>
    /// 현재 업그레이드 레벨에서 다음 업그레이드 레벨로 올라갈 때
    /// 필요한 골드 비용을 반환해 주는 함수
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public double GetCostByLevel(int level)
    {
        if (level < 0)
        {
            return 0;
        }
        return System.Math.Round(_baseCost * System.Math.Pow(_costMultiplier, level));
    }
}
