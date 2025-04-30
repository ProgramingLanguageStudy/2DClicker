using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
��������.
1. ���� �濡 �����Ϸ��� �� ������ ���谡 �ʿ��մϴ�.
�� ������ ���踦 enum���� ����� �ּ���.
(ex. ���� ����, Ǫ�� ����, ���� ����)

2. ������ ���� Ű(KeyCode.Return)�� ���� ������ �� ������ ���� ��
�� ������ ȹ���մϴ�.
ȹ���� ���踦 �ؽ��¿� ������ �ּ���.

3. ���ο� ���踦 ȹ�������� "00 ���踦 ȹ���߽��ϴ�!"�� �ֺܼ信 ��µǰ� �� �ּ���.

4. �̹� ȹ���� ���踦 �� ȹ��������
"00 ����� �̹� ������ �ֽ��ϴ�."�� ��µǰ� �� �ּ���.

(���� ���� X)
5. �� ����� ������ �����ϰ� ��� ���踦 ȹ��������,
"���� �濡 �����մϴ�!!"�� ��µǰ� �� �ּ���.
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
        _outputText.text = "���� �ִ� ����\n";
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
        if (_keyType.Add(key)) // �����Ͱ� �߰��� ���
        {
            Debug.Log($"{key}��(��) ȹ���߽��ϴ�!");
        }
        else // �����Ͱ� �߰����� ���� ���
        {
            Debug.Log($"{key}��(��) ȹ���߽��ϴ�!");
            Debug.Log($"{key}��(��) �̹� ������ �־ ȹ���� �Ұ��մϴ�.");
        }

        UpdateText();
        
        if (_keyType.Count == Enum.GetValues(typeof(KeyType)).Length)
        {
            Debug.Log("���� �濡 �����մϴ�!!");
            return;
        }
    }

    void UpdateText()
    {
        _outputText.text = "���� �ִ� ����\n";
        
        foreach (var key in _keyType)
        {
            _outputText.text += $"- {key}\n";
        }
    }
}
