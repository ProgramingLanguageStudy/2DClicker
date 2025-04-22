using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 세션(스테이지 진행)과 관계된 설정 데이터들
[CreateAssetMenu(menuName = "GameSettings/Session/SessionData", fileName = "SessionData")]
public class SessionData : ScriptableObject
{
    [SerializeField] int[] _enemyCountByTenStage;   // 10스테이지당 적 수 배열
    [SerializeField] double _baseHp;                // 적의 기본 체력
    [SerializeField] double _hpMultiplier;          // 스테이지당 적의 체력 비율

    [SerializeField] string _stageIndexTextFormat;  // 스테이지 번호 표시 형식
    [SerializeField] string _killCountTextFormat;   // 적 처치 수 표시 형식

    public string StageIndexTextFormat => _stageIndexTextFormat;
    public string KillCountTextFormat => _killCountTextFormat;

    /// <summary>
    /// 스테이지 순번(인덱스)에 따른 적의 수를 반환하는 함수
    /// </summary>
    /// <param name="stageIndex"></param>
    public int GetEnemyCountByStage(int stageIndex)
    {
        if(stageIndex<0)
        {
            return 0;
        }

        int index = stageIndex / 10;

        if (index >= _enemyCountByTenStage.Length)
        {
            index = _enemyCountByTenStage.Length - 1;
        }
        return _enemyCountByTenStage[index];
    }
    
    /// <summary>
    /// 스테이지 순번(인덱스)에 따른 적의 체력을 반환하는 함수
    /// </summary>
    /// <param name="stageIndex"></param>
    /// <returns></returns>
    public double GetHpByStage(int stageIndex)
    {
        if (stageIndex < 0)
        {
            return 0;
        }

        return _baseHp * System.Math.Pow(_hpMultiplier, stageIndex);
    }
}
