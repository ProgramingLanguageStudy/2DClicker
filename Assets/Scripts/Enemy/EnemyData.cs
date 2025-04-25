using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ĳ������ ���� �����͸� ����ϴ� ����
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
