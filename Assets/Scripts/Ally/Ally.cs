using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AllyType
{
    Archer,
    Warrior,
    Mages
}

// 동료 캐릭터를 제어하는 역할
// 1. 일정 시간 간격으로 총알을 생성해 발사
// 2. 레벨업 기능이 있어 레벨업 되면 스텟 강화
public class Ally : MonoBehaviour
{
    Session _session;
    AllyData _data;
    AllyUpgradeView _upgradeView;

    [SerializeField] Bullet _bulletPrefab;          // 총알 프리팹
    [SerializeField] Transform _bulletSpawnPoint;   // 총알 생성 포인트
    [SerializeField] Animator _animator;            // 애니메이터 컴포넌트 참조 변수

    float _attackSpan;             // 공격 시간 간격(초)
    float _bulletSpeed;            // 총알의 이동 속력
    double _damage;                // 총알 데미지

    int _level = 0;

    float _attackTimer;     // 공격 타이머

    public int Level => _level;

    public void Initialize(Session session, AllyData data, AllyUpgradeView upgradeView)
    {
        _session = session;
        _data = data;
        _upgradeView = upgradeView;

        _attackSpan = _data.AttackSpan;
        _bulletSpeed = _data.BulletSpeed;

        _attackTimer = _attackSpan;
    }

    // Update is called once per frame
    void Update()
    {
        _attackTimer -= Time.deltaTime;
        if(_attackTimer < 0 )
        {
            _attackTimer = _attackSpan;
            Attack();
        }
    }

    void Attack()
    {
        // 애니메이션 처리
        _animator.SetTrigger(AnimatorParameters.OnAttack);

        // 총알 생성
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = _bulletSpawnPoint.position;
        bullet.Initialize(_session, _session.Enemy.transform.position, _bulletSpeed, _damage);
    }

    /// <summary>
    /// 레벨을 1 증가시키는 함수
    /// </summary>
    public void AddLevel()
    {
        _level++;
        _damage += _data.GetDamageByLevel(_level);

        _upgradeView.UpdateView(_level, _damage);
    }
}
