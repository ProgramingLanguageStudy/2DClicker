using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SessionView : MonoBehaviour
{
    SessionData _data;

    [SerializeField] TextMeshProUGUI _stageIndexText;
    [SerializeField] TextMeshProUGUI _stageKillCountText;
    [SerializeField] TextMeshProUGUI _goldText;

    public void Initialize(SessionData data)
    {
        SetGoldText(0);
        _data = data;
    }

    /// <summary>
    /// �������� ��ȣ �ؽ�Ʈ UI�� ����(����)�ϴ� �Լ�
    /// </summary>
    /// <param name="stageIndex"></param>
    public void SetStageIndexText(int stageIndex)
    {
       //_stageIndexText.text = string.Format("Stage {0}", stageIndex + 1);
        _stageIndexText.text = string.Format(_data.StageIndexTextFormat, stageIndex + 1);
    }

    /// <summary>
    /// ų ī��Ʈ �ؽ�Ʈ UI�� ����(����)�ϴ� �Լ�
    /// </summary>
    /// <param name="killCount"></param>
    /// <param name="enemyCount"></param>
    public void SetKillCountText(int killCount, int enemyCount)
    {
        //_stageKillCountText.text = string.Format("{0}/{1}", killCount, enemyCount);
        _stageKillCountText.text = string.Format(_data.KillCountTextFormat, killCount, enemyCount);
    }

    public void SetGoldText(double gold)
    {
        string format = "{0:N0}";
        _goldText.text = gold.ToClikerString(format);
    }
}
