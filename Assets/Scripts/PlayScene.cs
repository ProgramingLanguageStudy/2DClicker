using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "Play" 씬을 총괄하는 클래스
public class PlayScene : MonoBehaviour
{
    [SerializeField] Hero _hero;
    [SerializeField] Enemy _enemy;

    private void Start()
    {
        _enemy.Initialize();        
    }
    public void Tap()
    {
        _hero.Attack(_enemy);
    }
}
