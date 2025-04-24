using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


// 적 캐릭터의 각 기능들을 관리하는(연결해 주는) 역할
public class Enemy : MonoBehaviour
{
    Session _session;

    EnemyStatusView _statusView;
    DamageViewSpawner _damageViewSpawner;

    [Header("----- 컴포넌트 참조 -----")]
    [SerializeField] EnemyStatus _status;
    [SerializeField] Transform _damageViewPoint;
    [SerializeField] EnemyView _view;

    public void Initialize(Session session, EnemyStatusView statusView, DamageViewSpawner damageViewSpawner, double maxHp, double rewardGold)
    {
        _session = session;
        _statusView = statusView;
        _damageViewSpawner = damageViewSpawner;

        _status.Initialize(maxHp, rewardGold);

        _statusView.SetNameText(_status.EnemyName);
        _statusView.SetHpBar(_status.CurrentHp, _status.MaxHp);
        _statusView.SetHpText(_status.CurrentHp);
    }

    public void TakeHit(double damage, bool isCritical)
    {
        // 공격받은 것에 대한 로직 처리
        _status.TakeDamage(damage, isCritical); 

        // UI 갱신(View 갱신, 유저에게 보여지는 부분 처리)
        _statusView.SetHpBar(_status.CurrentHp, _status.MaxHp);
        _statusView.SetHpText(_status.CurrentHp);

        // 데미지 텍스프 표시
        _damageViewSpawner.SpawnDamageView(_damageViewPoint.position, damage);

        // 사망 판단
        if (_status.IsAlive == false)
        {
            Die();
        }
    }

    /// <summary>
    /// 적이 죽는 처리를 해 주는 함수
    /// </summary>
    public void Die()
    {
        _session.OnEnemyDeath(_status.RewardGold);
        // _view.Dead(); // 죽는 애니메이션
        Destroy(gameObject);
    }

    
}
