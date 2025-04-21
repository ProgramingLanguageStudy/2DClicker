using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


// 적 캐릭터의 각 기능들을 관리하는(연결해 주는) 역할
public class Enemy : MonoBehaviour
{
    [Header("----- 컴포넌트 참조 -----")]
    [SerializeField] EnemyStatus _status;
    [SerializeField] EnemyStatusView _statusView;
    [SerializeField] EnemyView _view;
    [SerializeField] DamageViewSpawner _damageViewSpawner;
    [SerializeField] Transform _damageViewPoint;

    public void Initialize()
    {
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

        if (_status.CurrentHp <= 0)
        {
            Die();
        }

        // 데미지 텍스프 표시
        _damageViewSpawner.SpawnDamageView(_damageViewPoint.position, damage);
    }

    public void Die()
    {
        _view.Dead();
        Destroy(gameObject, 0.5f); // 애니메이션 끝나고 제거
    }

    
}
