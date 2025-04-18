using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 익스텐션(Extension, 확장 함수, 확장 메서드)
// 원본 클래스/구조체를 수정하지 않고도
// 해당 클래스/구조체에 함수를 추가한 것처럼 해 주는 기능

public static class Extension
{
    public static string ToClikerString(this double number, string format)
    {
        return Util.ToClikerString(number, format);
    }
}
