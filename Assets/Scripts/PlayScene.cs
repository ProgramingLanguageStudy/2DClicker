using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "Play" 씬을 총괄하는 클래스
public class PlayScene : MonoBehaviour
{
    [SerializeField] Hero _hero;
    [SerializeField] Session _session;
    [SerializeField] HeroUpgradeData _heroUpgradeData;
    [SerializeField] HeroUpgradeView _heroUpgradeView;

    private void Start()
    {
        _hero.Initialize();
        _session.Initialize();
        _heroUpgradeView.Initialize(_heroUpgradeData);
    }
    public void Tap()
    {
        _hero.Attack(_session.Enemy);
    }
}
