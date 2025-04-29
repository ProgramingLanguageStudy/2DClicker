using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

/*
�ؽ���(HashSet)
�ߺ� ����� ���� �ڷᱸ��

�迭, List�� �޸� ���� �ڷḦ �ϳ��� ������ �� �ִ�.
Contains()�� ������ �ڷ� ���� ������ Ȯ���� �� �ִ�.
(C++�� unordered_set)

�ؽ��ڵ�(� �����͸� ���ڷ� ��ȯ�ϴ� ��)�� ����ؼ�
�ڷ��� ���� ���θ� Ȯ���� �� �ֱ� ������
�ߺ� ���� �ڷ� ������ �ǰ�, � �ڷḦ �����ϰ� �ִ��� ���ε� ������ Ȯ�� ����

ex. ���� ������� ���� ���θ� �߿��� ���
�ߺ� ó�� �����ؾ� �ϴ� ���
� ����� � �׷쿡 ���ԵǴ��� ����

�ҿ� ���� ���� ����(������, ��Ʈ, ���̷���)
 */

public class HashSet : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _outputText;
    [SerializeField] TMP_InputField _inputField;

    // [SerializeField] �ص� �ν����ͺ信 ������ �ʴ´�.
    [SerializeField] HashSet<string> _fruitSet = new HashSet<string>();

    public void AddFruit(string fruit)
    {
        // �ؽ��¿� ������ �׸� �߰�
        // �̹� � ������ �����Ͱ� �ؽ��¿� ����Ǿ� ������
        // ���� �߰����� �ʴ´�.
        if (_fruitSet.Add(fruit)) // �����Ͱ� �߰��� ���
        {
            Debug.Log($"{fruit} �߰���");
        }
        else                    // �����Ͱ� �߰����� ���� ���
        {
            Debug.Log($"{fruit}��(��) �̹� ������");
        }

    }

    public void RemoveFruit()
    {
        string fruit = _inputField.text;
        if(_fruitSet.Remove(fruit))
        {
            Debug.Log($"{fruit} ���ŵ�");
        }
        else
        {
            Debug.Log($"{fruit}��(��) �������� ����");
        }
    }
}
