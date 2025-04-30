using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
연습문제.
1. 보스 방에 입장하려면 세 종류의 열쇠가 필요합니다.
세 종류의 열쇠를 enum으로 만들어 주세요.
(ex. 붉은 열쇠, 푸른 열쇠, 검은 열쇠)

2. 유저가 엔터 키(KeyCode.Return)를 누를 때마다 세 종류의 열쇠 중
한 가지를 획득합니다.
획득한 열쇠를 해쉬셋에 저장해 주세요.

3. 새로운 열쇠를 획득했으면 "00 열쇠를 획득했습니다!"가 콘솔뷰에 출력되게 해 주세요.

4. 이미 획득한 열쇠를 또 획득했으면
"00 열쇠는 이미 가지고 있습니다."가 출력되게 해 주세요.

(개수 저장 X)
5. 각 열쇠와 개수와 무관하게 모든 열쇠를 획득했으면,
"보스 방에 입장합니다!!"가 출력되게 해 주세요.
 */

public class HashSetPractice : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _outputText;

    public enum KeyType
    {
        RedKey,
        BlueKey,
        BlackKey,
    }

    [SerializeField] HashSet<KeyType> _keyType = new HashSet<KeyType>();


    void Start()
    {
        _outputText.text = "갖고 있는 열쇠\n";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Array keyValues = Enum.GetValues(typeof(KeyType));

            KeyType randomKey = (KeyType)keyValues.GetValue(UnityEngine.Random.Range(0, keyValues.Length));
            
            AddKey(randomKey);
        }
    }

    public void AddKey(KeyType key)
    {
        if (_keyType.Add(key)) // 데이터가 추가된 경우
        {
            Debug.Log($"{key}을(를) 획득했습니다!");
        }
        else // 데이터가 추가되지 않은 경우
        {
            Debug.Log($"{key}을(를) 획득했습니다!");
            Debug.Log($"{key}은(는) 이미 가지고 있어서 획득이 불가합니다.");
        }

        UpdateText();
        
        if (_keyType.Count == Enum.GetValues(typeof(KeyType)).Length)
        {
            Debug.Log("보스 방에 입장합니다!!");
            return;
        }
    }

    void UpdateText()
    {
        _outputText.text = "갖고 있는 열쇠\n";
        
        foreach (var key in _keyType)
        {
            _outputText.text += $"- {key}\n";
        }
    }
}
