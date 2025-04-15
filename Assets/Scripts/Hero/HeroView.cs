using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 주인공 캐릭터가 유저에게 보여지는 부분을 담당하는 클래스
public class HeroView : MonoBehaviour
{
    // 되도록이면 public 멤버 변수는 사용하지 말 것.
    // 다른 클래스 객체에서 해당 변수를 함부로 바꾸지 말아야 하기 때문.
    // -> 이런 일이 반복되면 우리 프로젝트 전체가 스파게티 코드

    // [SerializeField]: public이 아닌 private 멤버 변수를
    // 인스펙터뷰에서 설정할 수 있게 해 주는 기능(어트리뷰트)
    [SerializeField] Animator _animator;

    public void Attack()
    {
        //_animator.SetTrigger("OnAttack");
        _animator.SetTrigger(AnimatorParameters.OnAttack);
    }
}