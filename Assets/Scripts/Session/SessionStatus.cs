using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 세션(스테이지 진행)과 관계된 런타임 데이터들을 관리하는 역할
public class SessionStatus : MonoBehaviour
{
    SessionData _data;

    // 임시
    [SerializeField] int _stageIndex;   // 현재 스테이지 번호
    [SerializeField] int _stageEnemyCount;  // 현재 스테이지의 목표 적 수
    [SerializeField] int _stageKillCount;   // 현재 스테이지의 처치한 적 수
    
    public int StageIndex => _stageIndex;
    public int StageEnemyCount => _stageEnemyCount;
    public int StageKillCount => _stageKillCount;

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

    void NextStage()
    {
        _stageEnemyCount = 0;
        _stageIndex++;
        _stageEnemyCount = _data.GetEnemyCountByStage(_stageIndex);
    }
}
