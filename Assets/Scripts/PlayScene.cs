using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "Play" 씬을 총괄하는 클래스
public class PlayScene : MonoBehaviour
{
    [SerializeField] Hero _hero;

    [SerializeField] Enemy _enemy;

    [SerializeField] HeroUpgradeData _heroUpgradeData;

    [SerializeField] HeroUpgradeView _heroUpgradeView;

    private void Start()
    {
        _hero.Initialize();
        _enemy.Initialize();
        _heroUpgradeView.Initialize(_heroUpgradeData);
    }
    public void Tap()
    {
        _hero.Attack(_enemy);
    }
}
