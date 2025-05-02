using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ĳ���Ͱ� ������ �߻��ϴ� ����ü�� �����ϴ� ����
// 1. ������ �ڿ� �� ĳ���͸� ���� �̵�
// 2. �̵� ������ �ٶ󺸵��� ȸ��
// 3. �� ĳ���Ϳ��� ����� ������ �������� �� �������� ������ �Ѵ�.
public class Bullet : MonoBehaviour
{
    // �浹 ������ ���� �Ѱ� �Ÿ���
    const float _threshhold = 0.1f;

    // �� ĳ���͸� �������� ���� ������Ʈ ����
    [SerializeField] Session _session;

    // �Ѿ��� ��ǥ�� �ϴ� ������ ��ġ��
    [SerializeField] Vector3 _targetPos;

    // �̵� �ӷ�
    [SerializeField] float _speed;

    // ������ ���� ������
    [SerializeField] double _damage;

    // �̵� ����
    Vector3 _dir;

    public void Initialize(Session session, Vector3 targetPos, float speed, double damage)
    {
        _session = session;
        _targetPos = targetPos;
        _speed = speed;
        _damage = damage;

        // �̵� ���� ���
        _dir = (_targetPos - transform.position).normalized;

        // �ٶ󺸴� ���� ����
        transform.right = _dir;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, _targetPos);

        if (distance < _threshhold)
        {
            // �浹 ó��

            if (_session.Enemy != null)
            {
                _session.Enemy.TakeHit(_damage);
            }
            Destroy(gameObject);
        }
        else
        {
            // �̵� ó��
            // ���� ��ǥ�� �������� �̵� ó��
            transform.Translate(_dir * _speed * Time.deltaTime, Space.World);

            // ���� ��ǥ�� �������� �̵� ó��
            //transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.Self);
        }
    }
}
