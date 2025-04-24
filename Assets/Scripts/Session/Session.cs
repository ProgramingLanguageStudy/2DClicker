using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 세션(스테이지 진행)의 각 기능들을 총괄하는 역할
public class Session : MonoBehaviour
{
    [Header("----- 설정 데이터 -----")]
    [SerializeField] SessionData _data;

    [Header("----- 컴포넌트 참조 -----")]
    [SerializeField] SessionStatus _status;
    [SerializeField] SessionView _view;
    [SerializeField] Hero _hero;

    [Header("----- Enemy 생성 -----")]
    [SerializeField] Enemy[] _enemyPrefabs;                 // 적 프리팹 배열
    [SerializeField] Transform _enemySpawnPoint;            // 적 생성 위치 Transform
    [SerializeField] EnemyStatusView _enemyStatusView;
    [SerializeField] DamageViewSpawner _damageViewSpawner;

    // 현재 생성되어 있는 적
    Enemy _enemy;

    public Enemy Enemy => _enemy;

    public void Initialize()
    {
        _hero.Initialize(_status);
        _status.Initialize(_data);
        _view.Initialize(_data);

        _status.OnGoldChanged += _view.SetGoldText;

        SpawnEnemy();

        UpdateView();
    }

    /// <summary>
    /// 적을 생성하는 함수
    /// </summary>
    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, _enemyPrefabs.Length);
        Enemy enemyPrefab = _enemyPrefabs[randomIndex];
        //_enemy = Instantiate(enemyPrefab, _enemySpawnPoint.position, Quaternion.identity);
        _enemy = Instantiate(enemyPrefab, _enemySpawnPoint.position, _enemySpawnPoint.rotation);

        // this 키워드: 자기 자신 객체를 가리킨다.
        _enemy.Initialize(this, _enemyStatusView, _damageViewSpawner, _data.GetHpByStage(_status.StageIndex), _data.GetGoldByStage(_status.StageIndex));
    }

    /// <summary>
    ///  적이 죽었을 때 실행되는 함수
    /// </summary>
    public void OnEnemyDeath(double rewardGold)
    {
        _status.AddKillCount();
        _status.AddGold(rewardGold);

        SpawnEnemy();

        UpdateView();
    }

    /// <summary>
    /// 유저가 탭 했을 때 주인공이 공격하는 함수
    /// </summary>
    public void TapAttack()
    {
        _hero.Attack(_enemy);
    }

    /// <summary>
    /// SessionView를 갱신하는 함수
    /// </summary>
    public void UpdateView()
    {
        _view.SetStageIndexText(_status.StageIndex);
        _view.SetKillCountText(_status.StageKillCount, _status.StageEnemyCount);
    }
}
