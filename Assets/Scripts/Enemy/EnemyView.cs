using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void Dead()
    {
        //_animator.SetTrigger("OnAttack");
        _animator.SetTrigger(AnimatorParameters.OnDead);
    }
}
