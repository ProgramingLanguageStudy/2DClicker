using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
큐(Queue)
선입선출(FIFO: First In, First Out)
먼저 들어온 자료가 먼저 나오는 자료구조

ex. 작업 예약(행동 대기열), 네트워크 패킷 처리 등
 */

public class QueueStudy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textPrefab;
    [SerializeField] Queue<TextMeshProUGUI> _queue = new Queue<TextMeshProUGUI>();
    [SerializeField] int _counter = 0;

    void Enqueue()
    {
        TextMeshProUGUI text = Instantiate(_textPrefab, transform);
        text.text = _counter.ToString();
        _queue.Enqueue(text);
        _counter++;
    }

    void Dequeue()
    {
        if (_queue.Count == 0) return;

        TextMeshProUGUI text = _queue.Dequeue();
        text.color = Color.red;
    }

    void Peek()
    {
        if (_queue.Count == 0) return;

        TextMeshProUGUI text = _queue.Peek();
        text.color = Color.yellow;
    }

    void SetAllTextsColorRed()
    {
        foreach(var text in _queue)
        {
            text.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enqueue();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Dequeue();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Peek();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetAllTextsColorRed();
        }
    }
}
