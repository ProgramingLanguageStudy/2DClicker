using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

/*
해쉬셋(HashSet)
중복 비허용 집합 자료구조

배열, List와 달리 같은 자료를 하나만 저장할 수 있다.
Contains()로 빠르게 자료 존재 유무를 확인할 수 있다.
(C++의 unordered_set)

해쉬코드(어떤 데이터를 숫자로 변환하는 것)를 사용해서
자료의 존재 여부를 확인할 수 있기 때문에
중복 없이 자료 저장이 되고, 어떤 자료를 저장하고 있는지 여부도 빠르게 확인 가능

ex. 순서 상관없이 존재 여부만 중요한 경우
중복 처리 방지해야 하는 경우
어떤 대상이 어떤 그룹에 포함되는지 여부

불에 약한 몬스터 종류(슬라임, 앤트, 스켈레톤)
 */

public class HashSet : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _outputText;
    [SerializeField] TMP_InputField _inputField;

    // [SerializeField] 해도 인스펙터뷰에 보이지 않는다.
    [SerializeField] HashSet<string> _fruitSet = new HashSet<string>();

    public void AddFruit(string fruit)
    {
        // 해쉬셋에 저장할 항목 추가
        // 이미 어떤 동일한 데이터가 해쉬셋에 저장되어 있으면
        // 새로 추가되지 않는다.
        if (_fruitSet.Add(fruit)) // 데이터가 추가된 경우
        {
            Debug.Log($"{fruit} 추가됨");
        }
        else                    // 데이터가 추가되지 않은 경우
        {
            Debug.Log($"{fruit}은(는) 이미 존재함");
        }

    }

    public void RemoveFruit()
    {
        string fruit = _inputField.text;
        if(_fruitSet.Remove(fruit))
        {
            Debug.Log($"{fruit} 제거됨");
        }
        else
        {
            Debug.Log($"{fruit}은(는) 존재하지 않음");
        }
    }
}
