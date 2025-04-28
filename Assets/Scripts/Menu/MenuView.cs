  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Button _openButton;        
    [SerializeField] Button _closeButton;

    // Start is called before the first frame update
    void Start()
    {
        Open();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 메뉴를 여는 함수
    /// </summary>
    public void Open()
    {
        _animator.SetBool(AnimatorParameters.IsOpened, true);  
        _openButton.gameObject.SetActive(false);
        _closeButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// 메뉴를 닫는 함수
    /// </summary>
    public void Close()
    {
        _animator.SetBool(AnimatorParameters.IsOpened, false);
        _openButton.gameObject.SetActive(true);
        _closeButton.gameObject.SetActive(false);
    }

}
