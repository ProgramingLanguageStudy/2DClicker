using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
프로퍼티(property, 속성)
멤버 변수에 접근할 수 있게 해 주는 읽기/쓰기 함수의 문법
Getter, Setter 함수를 따로 매번 만들지 않고 간단하게 사용할 수 있는 방법
(사실은 함수)
 
유니티의 기존 컴포넌트들은 대부분 프로퍼티를 통해 멤버 변수를 제어

Getter란?
클래스 외부에서 해당 클래스 멤버 변수 값을 가져올 때 사용하는 함수

Setter란?
클래스 외부에서 해당 클래스 멤버 변수 값을 설정할 때 사용하는 함수

외부에서 함부로 어떤 객체의 값을 바꿀 수 없게 해야 한다.
그러지 않으면 의도치 않은 동작이 발생할 수 있기 때문.
그래서 되도록이면 public 멤버 변수를 사용하기보다
안전하게 멤버 변수를 수정할 수 있게 해야 한다.

이를 쉽게 해 주는 게 프로퍼티.
C#에서는 프로퍼티가 있어서 Getter, Setter 함수를 따로 만들 필요 없이
편하게 사용할 수 있다.
*/

// 적 캐릭터의 로직을 담당하는 역할

public class EnemyStatus : MonoBehaviour
{
    // float 대신 double형을 쓰는 이유
    // 클리커 게임이기 때문에 숫자가 천문학적으로 커질 수 있어서
    // 더 큰 범위 숫자까지 사용이 가능한 double형을 채택
    [SerializeField] string _enemyName; // 적 캐릭터 이름
    [SerializeField] double _maxHp;     // 최대 체력
    [SerializeField] double _currentHp; // 현재 체력

    [SerializeField] Enemy _enemy;

    // 프로퍼티
    public string EnemyName
    {
        get
        {
            return _enemyName;
        }
        //set
        //{
        //    _enemyName = value;
        //}
    }
    // public string EnemyName => _enemyName;
    // 읽기 전용 프로퍼티(어떤 변수를 외부에서 수정은 못 하지만, 읽게는 해 주는 프로퍼티)
    public double MaxHp => _maxHp;
    public double CurrentHp => _currentHp;


    // float형: 3.14f
    // double형: 3.14

    public void TakeDamage(double damage, bool isCritical)
    {
        _currentHp -= damage;

        if (_currentHp < 0)
        {
            _currentHp = 0;
        }
    }

}
