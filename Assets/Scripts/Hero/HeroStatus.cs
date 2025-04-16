using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 주인공 캐릭터의 스탯 종류
public enum HeroStatType
{
    Damage,          // 기본 공격력
    CriticalRate,    // 크리티컬 확률
    CriticalFactor,  // 크리티컬 계수
}

// 주인공 캐릭터의 로직을 담당하는 역할
public class HeroStatus : MonoBehaviour
{
    [Header("----- 스탯(능력치) -----")]
    [SerializeField] double[] _stats;       // 주인공 캐릭터의 스탯(능력치)

    // 각 스탯에 대한 읽기 전용 프로퍼티
    public double Damage => _stats[(int)HeroStatType.Damage];
    public double CriticalRate => _stats[(int)HeroStatType.CriticalRate];
    public double CriticalFactor => _stats[(int)HeroStatType.CriticalFactor];
    
    [SerializeField] bool _isCritical;      // 크리티컬 발생 여부

    public bool IsCritical => _isCritical;

    public double CalculatedDamage
    {
        get
        {
            _isCritical = Random.value < CriticalRate;
            double finalDamage = Damage;
            // 크리티컬 계산

            if (_isCritical)
            {
                finalDamage *= CriticalFactor;
            }

            return finalDamage;
        }
    }

    /// <summary>
    /// 주인공 캐릭터의 스탯을 증가시켜 주는 함수
    /// </summary>
    /// <param name="statType">스탯 종류</param>
    /// <param name="amount">증가시킬 수치</param>
    public void AddStat(HeroStatType statType, double amount)
    {
        _stats[(int)statType] += amount;
    }
    public double GetStat(HeroStatType statType)
    {
        return _stats[(int)statType];
    }
}
