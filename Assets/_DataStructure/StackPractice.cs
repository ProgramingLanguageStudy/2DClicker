using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StackPractice : MonoBehaviour
{
    List<string> _inputs = new List<string>()
    {
        "이동", "이동", "방어", "공격", "공격", "방어"
    };

    Stack<string> _commands = new Stack<string>();

    // 연습문제.
    // _inputs와 같이 사용자의 입력이 주어졌을 때
    // 스택을 활용해 키보드 z 키를 누르면 마지막 명령이 취소되게 하고
    // 이번에 취소된 명령이 무엇인지 콘솔뷰에 출력되게 해 주세요.
    // 더 이상 취소할 명령이 없는 경우에도 적당한 메세지가 출력되게 해 주세요.

    void Start()
    {
        // 초기 명령어 입력을 스택에 저장
        foreach (var input in _inputs)
        {
            _commands.Push(input);
            Debug.Log("명령 입력: " + input);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (_commands.Count > 0)
            {
                string canceledCommand = _commands.Pop();
                Debug.Log("명령 취소: " + canceledCommand);
            }
            else
            {
                Debug.Log("취소할 명령이 없습니다.");
            }
        }
    }
}
