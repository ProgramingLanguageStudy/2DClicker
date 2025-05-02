using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 동료 캐릭터를 제어하는 역할
// 1. 일정 시간 간격으로 총알을 생성해 발사
// 2. 레벨업 기능이 있어 레벨업 되면 스텟 강화
public class Ally : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;          // 총알 프리팹
    [SerializeField] Transform _bulletSpawnPoint;   // 총알 생성 포인트
    [SerializeField] Animator _animator;            // 애니메이터 컴포넌트 참조 변수

    [SerializeField] float _attackSpan;             // 공격 시간 간격(초)
    [SerializeField] float _bulletSpeed;            // 총알의 이동 속력
    [SerializeField] double _damage;                // 총알 데미지

    float _attackTimer;     // 공격 타이머

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
