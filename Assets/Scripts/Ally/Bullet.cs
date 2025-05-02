using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 동료 캐릭터가 적에게 발사하는 투사체를 제어하는 역할
// 1. 생성된 뒤에 적 캐릭터를 향해 이동
// 2. 이동 방향을 바라보도록 회전
// 3. 적 캐릭터에게 충분히 가까이 도달했을 때 데미지를 입혀야 한다.
public class Bullet : MonoBehaviour
{
    // 충돌 감지를 위한 한계 거리값
    const float _threshhold = 0.1f;

    // 적 캐릭터를 가져오기 위한 컴포넌트 참조
    [SerializeField] Session _session;

    // 총알이 목표로 하는 지점의 위치값
    [SerializeField] Vector3 _targetPos;

    // 이동 속력
    [SerializeField] float _speed;

    // 적에게 입힐 데미지
    [SerializeField] double _damage;

    // 이동 방향
    Vector3 _dir;

    public void Initialize(Session session, Vector3 targetPos, float speed, double damage)
    {
        _session = session;
        _targetPos = targetPos;
        _speed = speed;
        _damage = damage;

        // 이동 방향 계산
        _dir = (_targetPos - transform.position).normalized;

        // 바라보는 방향 설정
        transform.right = _dir;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, _targetPos);

        if (distance < _threshhold)
        {
            // 충돌 처리

            if (_session.Enemy != null)
            {
                _session.Enemy.TakeHit(_damage);
            }
            Destroy(gameObject);
        }
        else
        {
            // 이동 처리
            // 월드 좌표계 기준으로 이동 처리
            transform.Translate(_dir * _speed * Time.deltaTime, Space.World);

            // 로컬 좌표계 기준으로 이동 처리
            //transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.Self);
        }
    }
}
