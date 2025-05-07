using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

// 동료 캐릭터 시스템을 총괄하는 역할 담당
public class AllyController : MonoBehaviour
{
    Session _session;
    SessionStatus _sessionStatus;

    [SerializeField] AllyData[] _allyDatas;
    [SerializeField] AllyUpgradeView _upgradeViewPrefab;
    [SerializeField] Transform _upgradeViewParent;

    // 동료 캐릭터 데이터 딕셔너리
    Dictionary<AllyType, AllyData> _allyDataMap = new Dictionary<AllyType, AllyData> ();

    // 동료 캐릭터 게임오브젝트(Ally 컴포넌트) 딕셔너리
    Dictionary<AllyType, Ally> _allyMap = new Dictionary<AllyType, Ally> ();

    // 동료 캐릭터 업그레이드뷰 딕셔너리
    Dictionary<AllyType, AllyUpgradeView> _allyUpgradeViewMap = new Dictionary<AllyType, AllyUpgradeView>();

    public void Initialize(Session session, SessionStatus sessionStatus)
    {
        _session = session;
        _sessionStatus = sessionStatus;

        foreach(var allyData in _allyDatas)
        {
            // 동료 캐릭터 데이터 매핑(딕셔너리화)
            _allyDataMap[allyData.AllyType] = allyData;

            // 동료 캐릭터 업그레이드뷰 미리 생성
            AllyUpgradeView upgradeView = Instantiate(_upgradeViewPrefab, _upgradeViewParent);
            upgradeView.Initialize(allyData, this);

            // 생성된 동료 캐릭터 업그레이드뷰를 딕셔너리에 저장
            _allyUpgradeViewMap[allyData.AllyType] = upgradeView;
        }
    }

    public void Upgrade(AllyType allyType)
    {
        if (_allyDataMap.ContainsKey(allyType) == false) return;

        // 딕셔너리에서 해당하는 AllyData를 가져온다.
        AllyData data = _allyDataMap[allyType];

        // 이미 해당 동료 캐릭터가 생성되어 있는 경우
        if (_allyMap.ContainsKey(allyType) == true)
        {
            // 딕셔너리에서 해당하는 Ally를 가져온다.
            Ally ally = _allyMap[allyType];
            double cost = data.GetCostByLevel(ally.Level);

            // 레벨업 비용 지불에 성공하면
            if (_sessionStatus.TryPayGold(cost) == true)
            {
                // Ally의 레벨을 1 증가 시킨다.
                ally.AddLevel();
            }
        }

        // 해당 동료 캐릭터가 아직 생성되어 있지 않은 경우
        else
        {
            // 레벨업 비용 지불에 성공하면
            double cost = data.GetCostByLevel(0);
            if(_sessionStatus.TryPayGold(cost) == true)
            {
                // 동료 캐릭터 생성
                Ally ally = Instantiate(data.Prefab, transform);

                // Ally 컴포넌트 초기화
                ally.Initialize(_session, data, _allyUpgradeViewMap[allyType]);
                ally.AddLevel();

                // 동료 캐릭터(Ally 컴포넌트) 딕셔너리에 저장
                _allyMap[allyType] = ally;
            }
        }
    }
}
