using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 적 캐릭터의 설정 데이터를 담당하는 역할
[CreateAssetMenu(menuName = "GameSettings/Enemy/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] string _enemyName;
    [SerializeField] double _hpFactor;           
    [SerializeField] double _goldFactor;

    public string EnemyName => _enemyName;
    public double HpFactor => _hpFactor;
    public double GoldFactor => _goldFactor;
}
