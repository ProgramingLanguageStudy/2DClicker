using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "Play" 씬을 총괄하는 클래스
public class PlayScene : MonoBehaviour
{
    [SerializeField] Session _session;

    private void Start()
    {
        _session.Initialize();
    }
    public void Tap()
    {
        _session.TapAttack();
    }
}
