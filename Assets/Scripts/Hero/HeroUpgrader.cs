using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ���ΰ� ĳ������ ���׷��̵带 �� �ִ� ����
public class HeroUpgrader : MonoBehaviour
{
    [Header("----- ���׷��̵� ������ -----")]
    // ���ΰ� ĳ���� ���׷��̵� ������ �迭
    [SerializeField] HeroUpgradeData[] _upgradeDatas;

    [Header("----- ������Ʈ ���� -----")]
    [SerializeField] HeroStatus _status;
    [SerializeField] HeroUpgradeView[] _upgradeViews;

    // �ӽ�
    [SerializeField] int[] _upgradeLevels;

    public void Initialize()
    {
        _upgradeLevels = new int[_upgradeDatas.Length];

        for (int i = 0; i < _upgradeDatas.Length; i++)
        {
            _upgradeViews[i].Initialize(_upgradeDatas[i]);
            _upgradeViews[i].RefreshUI(_upgradeLevels[i]);
        }
    }

    public void Upgrade(int statIndex)
    {
        if (statIndex < 0 || statIndex >= _upgradeDatas.Length)
            return;

        Upgrade((HeroStatType)statIndex);
    }

    public void Upgrade(HeroStatType statType)
    {
        // statType�� int�� ��ȯ
        int statIndex = (int)statType;

        // ���׷��̵� ���� ����
        _upgradeLevels[statIndex]++;
        int level = _upgradeLevels[statIndex];

        // ���׷��̵� ������ ��������
        HeroUpgradeData upgradeData = _upgradeDatas[statIndex];

        // ���׷��̵� ��ġ �����ϱ�
        double value = upgradeData.GetValueByLevel(level);
        _status.AddStat(statType, value);

        _upgradeViews[statIndex].RefreshUI(level);
    }
}
