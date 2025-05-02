using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���� ĳ���͸� �����ϴ� ����
// 1. ���� �ð� �������� �Ѿ��� ������ �߻�
// 2. ������ ����� �־� ������ �Ǹ� ���� ��ȭ
public class Ally : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;          // �Ѿ� ������
    [SerializeField] Transform _bulletSpawnPoint;   // �Ѿ� ���� ����Ʈ
    [SerializeField] Animator _animator;            // �ִϸ����� ������Ʈ ���� ����

    [SerializeField] float _attackSpan;             // ���� �ð� ����(��)
    [SerializeField] float _bulletSpeed;            // �Ѿ��� �̵� �ӷ�
    [SerializeField] double _damage;                // �Ѿ� ������

    float _attackTimer;     // ���� Ÿ�̸�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
