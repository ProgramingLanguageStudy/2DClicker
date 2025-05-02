using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 주인공 캐릭터의 각 기능들을 총괄하는(관리하는) 클래스
public class Hero : MonoBehaviour
{
    [Header("----- 컴포넌트 참조 -----")]
    [SerializeField] HeroStatus _status;
    [SerializeField] HeroView _view;
    [SerializeField] HeroUpgrader _upgrader;
    [SerializeField] Session _session;

    // List<IHeroSkill> heroSkills = new List<IHeroSkill>(); // 일단 보류

    AutoAttackSkill _autoAttackSkill;
    PowerAttackSkill _powerAttackSkill;

    void Update()
    {
        // 자동 공격만 활성화 (자동 공격은 계속 반복되므로)
        _autoAttackSkill.Use();
    }

    public void Initialize(SessionStatus sessionStatus, Session session)
    {
        _session = session;
        _upgrader.Initialize(sessionStatus, _status);

        _autoAttackSkill = new AutoAttackSkill(this, session, _status);
        _powerAttackSkill = new PowerAttackSkill(this, session, _status, _view);
    }

    // 파워 어택 스킬 실행
    public void UsePowerAttackSkill()
    {
        _powerAttackSkill.Use();
    }

    // 기본 공격(자동 공격)
    public void UseAutoAttackSkill()
    {
        _autoAttackSkill.Use();
    }

    public void Attack(Enemy enemy, double damage)
    {
        enemy.TakeHit(damage);
        _view.Attack();
    }
}
