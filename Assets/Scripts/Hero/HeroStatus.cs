using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 주인공 캐릭터의 로직을 담당하는 역할
public class HeroStatus : MonoBehaviour
{
    [SerializeField] double _damage;        // 기본 공격력
    [SerializeField] float _criticalRate;   // 크리티컬 확률
    [SerializeField] float _criticalFactor; // 크리티컬 계수
    [SerializeField] bool _isCritical;      // 크리티컬 발생 여부

    public bool IsCritical => _isCritical;

    public double CalculatedDamage
    {
        get
        {
            _isCritical = Random.value < _criticalRate;
            double finalDamage = _damage;
            // 크리티컬 계산

            if (_isCritical)
            {
                finalDamage *= _criticalFactor;
            }

            return finalDamage;
        }
    }
}
