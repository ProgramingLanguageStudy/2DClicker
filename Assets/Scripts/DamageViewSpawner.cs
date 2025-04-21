using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DamageView를 원하는 위치에 생성하는 역할
public class DamageViewSpawner : MonoBehaviour
{
    // DamageView의 원본 프리펩
    [SerializeField] DamageView _damageViewPrefab;

    // DamageView를 생성할 부모 게임오브젝트의 RectTransform
    [SerializeField] RectTransform _damageViewParent;

    public void SpawnDamageView(Vector3 worldPos, double damage)
    {
        DamageView damageView = Instantiate(_damageViewPrefab, _damageViewParent.transform);

        //damageView.transform.position = worldPos; // 월드 위치를 UI 위치로 변환해야 한다.

        // 뷰포트 좌표계(ViewPort)를 활용한 방식
        //Vector3 viewportPos = Camera.main.WorldToViewportPoint(worldPos);
        //Vector2 anchoredPos = new Vector2(
        //    (viewportPos.x - 0.5f) * _damageViewParent.sizeDelta.x,
        //    (viewportPos.y - 0.5f) * _damageViewParent.sizeDelta.y);

        //damageView.RectTransform.anchoredPosition = anchoredPos;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _damageViewParent, screenPos, null, out Vector2 localPoint);

        damageView.RectTransform.anchoredPosition = localPoint;
    }
}
