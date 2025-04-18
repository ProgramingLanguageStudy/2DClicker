using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 적 캐릭터의 각 기능들을 관리하는(연결해 주는) 역할
public class Enemy : MonoBehaviour
{
    [Header("----- 컴포넌트 참조 -----")]
    [SerializeField] EnemyStatus _status;
    [SerializeField] EnemyStatusView _statusView;
    [SerializeField] EnemyView _view;

    [Header("----- 데미지 텍스트 관련 -----")]
    [SerializeField] GameObject _damageTextPrefab;   // 프리팹
    [SerializeField] Transform _damageTextParent;    // 캔버스나 UI 위치

    public void Initialize()
    {
        _statusView.SetNameText(_status.EnemyName);
        _statusView.SetHpBar(_status.CurrentHp, _status.MaxHp);
        _statusView.SetHpText(_status.CurrentHp);
    }

    public void TakeHit(double damage, bool isCritical)
    {
        _status.TakeDamage(damage, isCritical); // 체력 감소만 처리
        _statusView.SetHpBar(_status.CurrentHp, _status.MaxHp);
        _statusView.SetHpText(_status.CurrentHp);

        ShowDamageText(damage, isCritical); // 이곳에서 데미지 텍스트 출력

        if (_status.CurrentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _view.Dead();
        Destroy(gameObject, 0.5f); // 애니메이션 끝나고 제거
    }

    public void ShowDamageText(double damage, bool isCritical)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2f);

        Vector3 worldPos;
        RectTransform canvasRect = _damageTextParent.GetComponent<RectTransform>();

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect, screenPos, Camera.main, out worldPos))
        {
            GameObject dmgObj = Instantiate(_damageTextPrefab, worldPos, Quaternion.identity, _damageTextParent);
            DamageText dmgText = dmgObj.GetComponent<DamageText>();
            dmgText.Setup(damage, isCritical);
        }
    }
}
