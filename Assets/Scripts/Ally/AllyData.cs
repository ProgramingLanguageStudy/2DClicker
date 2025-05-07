using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="GameSettings/Ally/AllyData", fileName = "Ally")]
public class AllyData : ScriptableObject
{
    [SerializeField] AllyType _allyType;
    [SerializeField] string _allyName;      // 표시 이름
    [SerializeField] float _bulletSpeed;    // 총알 속력
    [SerializeField] float _attackSpan;     // 공격 간격
    [SerializeField] double _baseDamage;    // 기본 데미지
    [SerializeField] double _damageMultiplier;  // 데미지 계수
    [SerializeField] double _initialCost;   // 처음 구매 비용
    [SerializeField] double _baseCost;      // 구매 비용 증가 기본값
    [SerializeField] double _costMultiplier;    // 구매 비용 계수
    [SerializeField] Sprite _iconSprite;    // UI 표시용 스프라이트
    [SerializeField] Ally _prefab;          // 동료 캐릭터 프리팹

    public string AllyName => _allyName;
    public AllyType AllyType => _allyType;
    public float BulletSpeed => _bulletSpeed;
    public float AttackSpan => _attackSpan;
    public Sprite IconSprite => _iconSprite;
    public Ally Prefab => _prefab;

    public double GetDamageByLevel(int level)
    {
        if (level <= 0)
            return 0;
        return _baseDamage * System.Math.Pow(_damageMultiplier, level-1);
    }

    /// <summary>
    /// 비용 증가량을 반환해 주는 함수
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public double GetCostByLevel(int level)
    {
        if (level < 0)
            return 0;

        if (level == 0)
            return _initialCost;

        return System.Math.Round(_baseCost*System.Math.Pow(_costMultiplier, level-1));
    }
}
