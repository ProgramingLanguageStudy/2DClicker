using UnityEngine;

public interface IHeroSkill
{
    void Use();  // ������ ��ų�� ����� �� ȣ��Ǵ� �޼���
}

public class AutoAttackSkill : IHeroSkill
{
    Hero _hero;
    Session _session;  // Session�� ����
    private float _attackInterval = 1f; // 1�ʸ��� ����
    private float _attackTimer = 0f;

    // �����ڿ��� Hero�� Session�� ����
    public AutoAttackSkill(Hero hero, Session session)
    {
        _hero = hero;
        _session = session;  // Session�� ����
    }

    public void Use()
    {
        // �ڵ� ���� ����
        _attackTimer += Time.deltaTime;

        if (_attackTimer >= _attackInterval)
        {
            _attackTimer = 0f;
            _hero.Attack(_session.Enemy);  // Session���� ���� �����ͼ� ����
            Debug.Log("Auto Attack!");
        }
    }
}