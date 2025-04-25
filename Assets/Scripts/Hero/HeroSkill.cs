using UnityEngine;

public interface IHeroSkill
{
    void Use();  // 영웅이 스킬을 사용할 때 호출되는 메서드
}

public class AutoAttackSkill : IHeroSkill
{
    Hero _hero;
    Session _session;  // Session을 참조
    private float _attackInterval = 1f; // 1초마다 공격
    private float _attackTimer = 0f;

    // 생성자에서 Hero와 Session을 받음
    public AutoAttackSkill(Hero hero, Session session)
    {
        _hero = hero;
        _session = session;  // Session을 저장
    }

    public void Use()
    {
        // 자동 공격 로직
        _attackTimer += Time.deltaTime;

        if (_attackTimer >= _attackInterval)
        {
            _attackTimer = 0f;
            _hero.Attack(_session.Enemy);  // Session에서 적을 가져와서 공격
            Debug.Log("Auto Attack!");
        }
    }
}