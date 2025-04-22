using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 유저에게 데미지 텍스트 애니메이션 연출을 보여 주는 역할
public class DamageView : MonoBehaviour
{
    [Header("----- 컴포넌트 참조 -----")]
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] TextMeshProUGUI _text;

    [Header("----- 설정값 -----")]
    // 애니메이션 지속 시간
    [SerializeField] float _duration;

    public RectTransform RectTransform => _rectTransform;

    // 애니메이션 타이머
    float _timer;

    private void Start()
    {
        _timer = _duration;
    }

    public void SetDamageText(double damage)
    {
        _text.text = damage.ToClikerString("{0:N0}");
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            Destroy(gameObject);
        }
    }
}

//public class DamageView : MonoBehaviour
//{
//    [Header("----- 컴포넌트 참조 -----")]
//    // 자식 오브젝트(텍스트)의 RectTransform 찹조
//    [SerializeField] RectTransform _textRectTransform;

//    // 자식 오브젝트(텍스트)의 TMP 컴포넌트 참조
//    [SerializeField] TextMeshProUGUI _text;

//    // 데미지 텍스트 애니메이션의 목표 지점
//    [SerializeField] Vector2 _targetPos;

//    // 데미지 텍스트 애니메이션의 지속 시간
//    [SerializeField] float _animDuration;

//    // 데미지 텍스트가 움직이는 초당 속력
//    float _moveSpeed;

//    void Start()
//    {
//        // '속력 = 거리/시간'인 점을 이용해 속력을 미리 계산
//        _moveSpeed = Vector2.Distance(_textRectTransform.anchoredPosition, _targetPos) / _animDuration;
//    }

//    void Update()
//    {
//        // MoveTowards(Vector2 current, Vector2 target, float maxDeltaDistance)
//        // 현재 위치(current)에서 목표 위치(target)로
//        // 최대 이동 거리만큼만 이동 시킨 위치 값을 되돌려 주는 함수
//        // Update()와 같이 지속 실행하는 경우와 함께 사용하여 게임오브젝트를 목표한 위치까지
//        // 지속적으로 이동시킬 때 유용
//        _textRectTransform.anchoredPosition =
//            Vector2.MoveTowards(_textRectTransform.anchoredPosition, _targetPos, _moveSpeed * Time.deltaTime);

//        // Color: r, g, b, a 네 가지 값을 가지고 색상을 표현하는 구조체 자료형
//        // Color는 r, g, b, a가 0.0f ~ 1.0f 값을 갖는 float 자료형
//        // Color32는 r, g, b, a가 0 ~ 255 값을 갖는 byte(정수) 자료형

//        Color color = _text.color;
//        color.a -= 1 / _animDuration * Time.deltaTime;
//        _text.color = color;

//    }
//}
