using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
ť(Queue)
���Լ���(FIFO: First In, First Out)
���� ���� �ڷᰡ ���� ������ �ڷᱸ��

ex. �۾� ����(�ൿ ��⿭), ��Ʈ��ũ ��Ŷ ó�� ��
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
