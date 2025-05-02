using UnityEngine;

public interface IHeroSkill
{
    void Use();  // 영웅이 스킬을 사용할 때 호출되는 메서드
}

public class AutoAttackSkill : IHeroSkill
{
    Hero _hero;
    Session _session;  // Session을 참조
    HeroStatus _status; 
    
    private float _attackInterval = 1f; // 1초마다 공격
    private float _attackTimer = 0f;

    // 생성자에서 Hero와 Session을 받음
    public AutoAttackSkill(Hero hero, Session session, HeroStatus status)
    {
        _hero = hero;
        _session = session;  // Session을 저장(Session에 Enemy가 있음)
        _status = status;
    }

    public void Use()
    {
        // 자동 공격 로직
        _attackTimer += Time.deltaTime;

        if (_attackTimer >= _attackInterval)
        {
            _attackTimer = 0f;
            _hero.Attack(_session.Enemy, _status.CalculatedDamage);  // Session에서 적을 가져와서 공격
            Debug.Log("Auto Attack!");
        }
    }
}

public class PowerAttackSkill : IHeroSkill
{
    Hero _hero;
    Session _session;  // Session을 참조
    HeroStatus _status;
    HeroView _view;

    public PowerAttackSkill(Hero hero, Session session, HeroStatus status, HeroView view)
    {
        _hero = hero;
        _session = session;  // Session을 저장(Session에 Enemy가 있음)
        _status = status;
        _view = view;
    }

    public void Use()
    {
        double pDamage = 5 * _status.CalculatedDamage;
        _session.Enemy.TakeHit(pDamage);
        _view.PowerAttackSkill();
        Debug.Log($"Power Attack! {pDamage}");
    }
}