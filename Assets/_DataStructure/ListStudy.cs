using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 리스트(List)
// 배열처럼 같은 자료형인 데이터를 연속적으로 저장할 수 있는 자료구조
// 배열 기능에 더해 데이터의 추가/삭제가 가능하다. 

public class ListStudy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textPrefab;
    [SerializeField] List<TextMeshProUGUI> _texts = new List<TextMeshProUGUI>();

    void AddText()
    {
        TextMeshProUGUI text = Instantiate(_textPrefab, transform);
        text.text = _texts.Count.ToString();
        _texts.Add(text);
    }

    void RemoveLastText()
    {
        if (_texts.Count == 0) return;

        TextMeshProUGUI text = _texts[_texts.Count - 1];
        Destroy(text.gameObject);
        _texts.RemoveAt(_texts.Count - 1);
    }

    void RemoveAllTexts()
    {
        foreach(TextMeshProUGUI text in _texts)
        {
            Destroy(text.gameObject);
        }
        _texts.Clear();
    }

    // 이름 짓는 법
    // 뭔가를 설정할 때 Set, 뭔가를 가져올 때 Get
    // 동사 + 대상 + (값, 설명)
    void SetAllTextsColorRed()
    {
        // var: 자료형을 우리가 직접 정하지 않고 컴퓨터가 정하게 해 주는 키워드
        // 자료형을 쓸 때 어떤 자료형이 무엇인지 확실한 경우에만 사용
        foreach(var text in _texts)
        {
            text.color = Color.red;
        }
    }
    void SetAllTextsColorWhite()
    {
        foreach (var text in _texts)
        {
            text.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            AddText();
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            RemoveLastText();
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            SetAllTextsColorRed();
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            SetAllTextsColorWhite();
        }

        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            RemoveAllTexts();
        }
    }

}
