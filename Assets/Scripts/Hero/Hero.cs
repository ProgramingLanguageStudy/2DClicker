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

    List<IHeroSkill> heroSkills = new List<IHeroSkill>();

    
    void Update()
    {
        // 매 프레임마다 스킬 활성화
        ActivateSkills();
    }

    public void Initialize(SessionStatus sessionStatus)
    {
        _upgrader.Initialize(sessionStatus, _status);

        heroSkills.Add(new AutoAttackSkill(this, sessionStatus.GetComponent<Session>()));
    }

    public void ActivateSkills()
    {
        foreach (var skill in heroSkills)
        {
            skill.Use();
        }
    }

    public void Attack(Enemy enemy)
    {
        double damage = _status.CalculatedDamage;
        bool isCritical = _status.IsCritical;

        enemy.TakeHit(damage, isCritical);

        _view.Attack();
    }
}
