using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static DictionaryStudy;
using static UnityEditor.Progress;

/*
연습문제.
0. 딕셔너리를 활용하여 각 아이템에 Id(int)를 부여해 아이템 정보를 조회하고,
인벤토리에 각 아이템 개수가 얼마나 보관되어 있는지 확인하는 시스템을 만들려 합니다.

1. _itemMap이라는 이름의 int - ItemData 딕셔너리를 만들어 주세요.
이 딕셔너리는 아이템의 정보를 저장하는 일종의 데이터베이스 역할을 합니다.

2. _itemInventory라는 이름의 int - int 딕셔너리를 만들어 주세요.
이 딕셔너리는 현재 보유한 아이템의 개수를 저장하는 인벤토리 역할을 합니다.

3. Start()에서 3~5개의 임의의 아이디와 이름을 가진 ItemData를 생성하여
_itemMap에 저장해 주세요.

4. 엔터 키를 누르면 _itemMap에 저장되어 있는 ItemData들 중 랜덤하게 하나를 골라
그것의 인벤토리에서 보유 개수를 1 증가되도록 해 주세요.
(List<int> itemIds = new List<int>(_itemMap.Keys);

어떤 아이템을 획득했는지, 그것의 현재 개수가 몇 개인지,
게임 화면에 TMP로 표시되게 해 주세요.

5. I 키를 누르면 인벤토리에 저장된 정보를 바탕으로
모든 "{아이템 이름}: {아이템 개수}개"가 TMP로 표시되게 해 주세요.
*/


public class DictionaryPractice : MonoBehaviour
{
    public class ItemData
    {
        int _id;
        string _name;
        public int Id => _id;
        public string Name => _name;

        public ItemData(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }

    Dictionary<int, ItemData> _itemMap
        = new Dictionary<int, ItemData>();

    Dictionary<int, int> _itemInventory
        = new Dictionary<int, int>();

    List<int> _itemIds = new List<int>();

    [SerializeField] TextMeshProUGUI _outputText;

    // Start is called before the first frame update
    void Start()
    {
        _outputText.text = "현재 인벤토리 목록: \n";

        _itemMap[0] = new ItemData(1000, "체력 포션");
        _itemMap[1] = new ItemData(1001, "마나 포션");
        _itemMap[2] = new ItemData(1002, "엉결불 포션");
        _itemMap[3] = new ItemData(1003, "얼음무구 포션");
        _itemMap[4] = new ItemData(1004, "먹구름 포션");

        _itemIds = new List<int>(_itemMap.Keys);

        foreach (int id in _itemIds)
        {
            _itemInventory[id] = 0;
        }
    }

    public void RandomAddItem()
    {
        int randomIndex = Random.Range(0, _itemIds.Count);   // 0 ~ Count - 1
        int randomItemId = _itemIds[randomIndex];            // 랜덤한 아이템 ID 선택

        _itemInventory[randomItemId] += 1;                  // 해당 아이템 개수 +1
        ItemData item = _itemMap[randomItemId];
        _outputText.text = $"{item.Name}을(를) 획득했습니다!\n현재 개수: {_itemInventory[randomItemId]}개";
    }

    void ShowInventory()
    {
        _outputText.text = "현재 인벤토리 목록:\n";
        foreach (int id in _itemIds)
        {
            string itemName = _itemMap[id].Name;
            int count = _itemInventory[id];
            _outputText.text += $"{itemName}: {count}개\n";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RandomAddItem(); // 🔸 리스트는 내부에서 접근
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }
    }
}
