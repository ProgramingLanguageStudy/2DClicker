using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
��ųʸ�(Dictionary, ����)
Key-Value(Ű-��) ������ �����͸� �����ϴ� �ڷᱸ��
KeyValuePair<TKey, TValue<��� ����ü�� ���
�ϳ��� Ű�� �ϳ��� ���� ������Ų��.

List, HashSet�� �޸� Key�� �������� ���� �����ϰ� ã�´�.
ContainsKey()�� � Key�� ���� ������ ������ Ȯ���� �� �ִ�.
(C++�� unordered_map�� ����)

�߰��� �����͵��� ������ ��������� �ʴ´�.

ex. �̸����� ���� ����
������ ID�� ������ ���� ã��
*/

public class DictionaryStudy : MonoBehaviour
{
    public class Student
    {
        string _name;
        int _score;

        public string Name => _name;
        public int Score => _score;

        // ������
        public Student(string name, int score)
        {
            _name = name;
            _score = score;
        }

        public void SetScore(int score)
        {
            _score = score;
        }
    }

    [SerializeField] TextMeshProUGUI _outputText;
    [SerializeField] TMP_InputField _keyInputField;
    [SerializeField] TMP_InputField _valueInputField;

    Dictionary<string, Student> _studentsMap
        = new Dictionary<string, Student> ();

    /// <summary>
    /// �л������� �̹� ������ �����ϴ� �Լ�
    /// </summary>
    public void AddOrUpdateStudent()
    {
        string name = _keyInputField.text;
        int score = 0;

        // int.TryParse()
        // ���ڿ��� int�� ��ȯ�ϴ� �Լ�
        if(int.TryParse(_valueInputField.text, out score) == false)
        {
            Debug.Log("������ ���ڷ� �Է��� �ּ���.");
            return;
        }

        // �̹��� �Է��� �л� �̸��� ��ųʸ� Ű�� ��������
        if(_studentsMap.ContainsKey(name) == false)
        {
            // �� Student ��ü�� ����
            Student newStudent = new Student(name, score);

            // ��ųʸ��� ����
            // (���� key�� �� Add()�� �Ϸ��ϸ� ����)
            _studentsMap.Add(name, newStudent);

            // �ȳ� �޽��� ���
            Debug.Log($"{name} �л��� ��ϵǾ����ϴ�. ����: {score}��");
        }

        else
        {
            // _studentMap[(key�� �ڷ����� ���� ����)]

            // ��ųʸ����� key�� �Է��ϸ� �ٷ� �����ϴ�
            // vlaue�� �޾� �� �� �ִ�.
            // (������ ���� key�� �����ϴ� value�� ���������� �ϸ� ����)
            Student student = _studentsMap[name];
            student.SetScore(score);
            Debug.Log($"{name}�� ������ {score}������ �����Ǿ����ϴ�.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
