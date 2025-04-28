using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
스택(Stack)
후입선출(LIFO: Last In, First Out)
나중에 들어온 자료가 먼저 나오는 자료구조

ex. 명령 되돌리기(Ctrl + z), 팝업창 순서대로 닫기
오브젝트풀 (Object Pool)
 */
public class StackStudy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textPrefab;

    // 인스펙터뷰에 보이지 않는다.
    [SerializeField] Stack<TextMeshProUGUI> _stack = new Stack<TextMeshProUGUI>();
    [SerializeField] int _counter = 0;

    void Push()
    {
        TextMeshProUGUI text = Instantiate(_textPrefab, transform);
        text.text = _counter.ToString();
        _stack.Push(text);

        _counter++;
    }

    void Pop()
    {
        if (_stack.Count == 0) return;

        // 스택에 저장된 요소(자료) 중 가장 마지막에 저장된 요소(자료)를 꺼내 온다.
        TextMeshProUGUI text = _stack.Pop();
        text.color = Color.red;
    }

    void Peak()
    {
        if (_stack.Count == 0) return; 

        // 스택에 저장된 요소(자료) 중 가장 마지막에 저장된 요소(자료)를 엿본다.
        // (해당 자료가 스택에서 빠지지는 않는다.)
        TextMeshProUGUI text = _stack.Peek();
        text.color = Color.yellow;
    }

    void SetAllTextsColorRed()
    {
        foreach(var text in _stack)
        {
            text.color = Color.red;
        }
    }

    void SetAllTextsColorWhite()
    {
        foreach (var text in _stack)
        {
            text.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Push();
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Pop();
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Peak();
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            SetAllTextsColorRed();
        }

        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            SetAllTextsColorWhite();
        }
    }
}
