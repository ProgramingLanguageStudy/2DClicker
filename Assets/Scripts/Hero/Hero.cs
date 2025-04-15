using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 주인공 캐릭터의 각 기능들을 총괄하는(관리하는) 클래스
public class Hero : MonoBehaviour
{
    [Header("----- 컴포넌트 참조 -----")]
    [SerializeField] HeroStatus _status;
    [SerializeField] HeroView _view;

    public void Attack(Enemy enemy)
    {
        double damage = _status.CalculatedDamage;
        bool isCritical = _status.IsCritical;

        enemy.TakeHit(damage, isCritical);

        _view.Attack();
    }

}
