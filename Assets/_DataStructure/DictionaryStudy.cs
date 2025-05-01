using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
딕셔너리(Dictionary, 사전)
Key-Value(키-값) 상으로 데이터를 저장하는 자료구조
KeyValuePair<TKey, TValue<라는 구조체를 사용
하나의 키에 하나의 값을 대응시킨다.

List, HashSet과 달리 Key를 기준으로 값을 저장하고 찾는다.
ContainsKey()로 어떤 Key의 존재 유무를 빠르게 확인할 수 있다.
(C++의 unordered_map과 유사)

추가한 데이터들의 순서가 보장되지는 않는다.

ex. 이름으로 점수 관리
아이템 ID로 아이템 정보 찾기
*/

public class DictionaryStudy : MonoBehaviour
{
    public class Student
    {
        string _name;
        int _score;

        public string Name => _name;
        public int Score => _score;

        // 생성자
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

    Dictionary<string, Student> _studentMap
        = new Dictionary<string, Student> ();

    /// <summary>
    /// 학생정보가 이미 있으면 갱신하는 함수
    /// </summary>
    public void AddOrUpdateStudent()
    {
        string name = _keyInputField.text;
        int score = 0;

        // int.TryParse()
        // 문자열을 int로 변환하는 함수
        if(int.TryParse(_valueInputField.text, out score) == false)
        {
            Debug.Log("점수는 숫자로 입력해 주세요.");
            return;
        }

        // 이번에 입력한 학생 이름이 딕셔너리 키에 없었으면
        if(_studentMap.ContainsKey(name) == false)
        {
            // 새 Student 객체를 생성
            Student newStudent = new Student(name, score);

            // 딕셔너리에 저장
            // (같은 key로 또 Add()를 하려하면 에러)
            //_studentMap.Add(name, newStudent);

            // 만약에, 이미 있는 key인 경우
            // 그 key와 연결된 value를 수정
            // 만약에, 없는 key인 경우
            // 새로 key를 만들어서 그 key와 연결된 value를 설정
            _studentMap[name] = newStudent;

            // 안내 메시지 출력
            Debug.Log($"{name} 학생이 등록되었습니다. 점수: {score}점");
        }

        else
        {
            // _studentMap[(key의 자료형을 가진 변수)]

            // 딕셔너리에서 key를 입력하면 바로 대응하는
            // vlaue를 받아 올 수 있다.
            // (기존에 없던 key에 대응하는 value를 가져오려고 하면 에러)
            Student student = _studentMap[name];
            student.SetScore(score);
            Debug.Log($"{name}의 점수가 {score}점으로 수정되었습니다.");
        }

        UpdateText();
    }

    public void RemoveStudent()
    {
        string name = _keyInputField.text;

        // name key에 해당하는 key와 value를 모두 제거
        // 제거가 성공한 경우
        if (_studentMap.Remove(name) == true)
        {
            Debug.Log($"{name} 학생이 삭제되었습니다.");
        }

        else
        {
            Debug.Log($"{name} 학생은 등록되어 있지 않습니다.");
        }

        UpdateText();
    }

    public void SearchStudent()
    {
        string name = _keyInputField.text;

        //if (_studentMap.ContainsKey(name) == true)
        //{
        //    Student student = _studentMap[name];
        //    Debug.Log($"{student.Name} 학생의 점수는 {student.Score}점 입니다.");
        //}
        //else
        //{
        //    Debug.Log($"{name} 학생은 등록되어 있지 않습니다.");
        //}

        if(_studentMap.TryGetValue(name, out Student student) == true)
        {
            Debug.Log($"{student.Name} 학생의 점수는 {student.Score}점 입니다.");
        }
        else
        {
            Debug.Log($"{name} 학생은 등록되어 있지 않습니다.");
        }
    }

    void UpdateText()
    {
        _outputText.text = "학생 목록\n";
        foreach(KeyValuePair<string, Student> pair in _studentMap)
        {
            _outputText.text += $" {pair.Value.Name}: {pair.Value.Score}점\n";
        }

        /// var 키워드 사용한 foreach문
        //foreach(var pair in _studentMap)
        //{
        //    _outputText.text += $" {pair.Key}: {pair.Value.Score}점\n";
        //}

        // Dictionary.Values를 사용한 foreach문
        //foreach(Student student in _studentMap.Values)
        //{
        //    _outputText.text += $" {student.Name}: {student.Score}점\n";
        //}
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
