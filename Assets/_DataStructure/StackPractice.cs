using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StackPractice : MonoBehaviour
{
    List<string> _inputs = new List<string>()
    {
        "�̵�", "�̵�", "���", "����", "����", "���"
    };

    Stack<string> _commands = new Stack<string>();

    // ��������.
    // _inputs�� ���� ������� �Է��� �־����� ��
    // ������ Ȱ���� Ű���� z Ű�� ������ ������ ����� ��ҵǰ� �ϰ�
    // �̹��� ��ҵ� ����� �������� �ֺܼ信 ��µǰ� �� �ּ���.
    // �� �̻� ����� ����� ���� ��쿡�� ������ �޼����� ��µǰ� �� �ּ���.

    void Start()
    {
        // �ʱ� ��ɾ� �Է��� ���ÿ� ����
        foreach (var input in _inputs)
        {
            _commands.Push(input);
            Debug.Log("��� �Է�: " + input);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (_commands.Count > 0)
            {
                string canceledCommand = _commands.Pop();
                Debug.Log("��� ���: " + canceledCommand);
            }
            else
            {
                Debug.Log("����� ����� �����ϴ�.");
            }
        }
    }
}
