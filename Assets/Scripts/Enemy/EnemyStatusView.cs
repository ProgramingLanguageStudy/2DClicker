using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 적 캐릭터의 스테이터스를 유저에게 보여 주는 역할
public class EnemyStatusView : MonoBehaviour
{
    [Header("----- 컴포넌트 참조 -----")]
    [SerializeField] Image _hpBar;              // 체력바 이미지(Image) 컴포넌트
    [SerializeField] TextMeshProUGUI _hpText;   // 체력 텍스트(TMP) 컴포넌트
    [SerializeField] TextMeshProUGUI _nameText; // 이름 텍스트(TMP) 컴포넌트

    public void SetNameText(string name)
    {
        _nameText.text = name;
    }
    public void SetHpBar(double curHp, double maxHp)
    {
        _hpBar.fillAmount = (float)(curHp / maxHp);
    }
    public void SetHpText(double curHp)
    {
        //_hpText.text = curHp + "HP";
        //_hpText.text = $"{curHp} HP";

        //string format = "{0:N0} HP";
        //_hpText.text = Util.ToClikerString(curHp, format);

        string format = "{0:N0} HP";
        _hpText.text = curHp.ToClikerString(format);
    }
}
