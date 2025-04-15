using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 적 캐릭터의 각 기능들을 관리하는(연결해 주는) 역할
public class Enemy : MonoBehaviour
{
    [Header("----- 컴포넌트 참조 -----")]
    [SerializeField] EnemyStatus _status;
    [SerializeField] EnemyStatusView _statusView;

    [Header("----- 데미지 텍스트 관련 -----")]
    [SerializeField] GameObject DamageText;   // 프리팹
    [SerializeField] Transform DamageTextParent;    // 캔버스나 UI 위치

    public void Initialize()
    {
        _statusView.SetNameText(_status.EnemyName);
        _statusView.SetHpBar(_status.CurrentHp, _status.MaxHp);
        _statusView.SetHpText(_status.CurrentHp);
    }

    public void TakeHit(double damage, bool isCritical)
    {
        _status.TakeDamage(damage);
        _statusView.SetHpBar(_status.CurrentHp, _status.MaxHp);
        _statusView.SetHpText(_status.CurrentHp);

        ShowDamageText(damage, isCritical);
    }

    private void ShowDamageText(double damage, bool isCritical)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2f);

        Vector3 worldPos;
        RectTransform canvasRect = DamageTextParent.GetComponent<RectTransform>();

        // 스크린 좌표를 월드 좌표로 변환
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect, screenPos, Camera.main, out worldPos))
        {
            GameObject dmgObj = Instantiate(DamageText, worldPos, Quaternion.identity, DamageTextParent);
            DamageText dmgText = dmgObj.GetComponent<DamageText>();
            dmgText.Setup(damage, isCritical);
        }
    }
}
