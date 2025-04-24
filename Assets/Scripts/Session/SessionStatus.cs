using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 세션(스테이지 진행)과 관계된 런타임 데이터들을 관리하는 역할
public class SessionStatus : MonoBehaviour
{
    SessionData _data;

    // 임시
    [SerializeField] double _gold;

    [SerializeField] int _stageIndex;   // 현재 스테이지 번호
    [SerializeField] int _stageEnemyCount;  // 현재 스테이지의 목표 적 수
    [SerializeField] int _stageKillCount;   // 현재 스테이지의 처치한 적 수
    
    public int StageIndex => _stageIndex;
    public int StageEnemyCount => _stageEnemyCount;
    public int StageKillCount => _stageKillCount;
    public double Gold => _gold;

    public event Action<double> OnGoldChanged;

    public void Initialize(SessionData data)
    {
        _data = data;

        _stageIndex = 0;
        _stageEnemyCount = _data.GetEnemyCountByStage(_stageIndex);
        _stageKillCount = 0;
    }

    /// <summary>
    /// 현재 스테이지에서 처치한 적 수를 1 증가시키는 함수
    /// </summary>
    public void AddKillCount()
    {
        _stageKillCount++;

        if (_stageKillCount >= _stageEnemyCount)
        {
            // 다음 스테이지로
            NextStage();
        }
    }

    /// <summary>
    /// 보유 골드를 증가시키는 함수
    /// </summary>
    /// <param name="amount"></param>
    public void AddGold(double amount)
    {
        _gold += amount;
        OnGoldChanged?.Invoke(_gold);
        if (_gold < 0 )
        {
            _gold = 0;
        }


    }

    /// <summary>
    /// 골드 지불을 시도하는 함수
    /// </summary>
    /// <param name="amount">지불할 비용 골드</param>
    /// <returns>지불 성공 여부</returns>
    public bool TryPayGold(double amount)
    {
        if(_gold >= amount)
        {
            // 골드 소모
            AddGold(-amount);

            return true;
        }
        return false;
    }

    void NextStage()
    {
        _stageKillCount = 0;
        _stageIndex++;
        _stageEnemyCount = _data.GetEnemyCountByStage(_stageIndex);
    }
}
