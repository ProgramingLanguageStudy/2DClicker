using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// static: 정적인
// static 클래스는 객체를 만들지 않고 클래스 자체로 사용하겠다는 뜻
public static class Util
{
    static string[] _fixedUnits = { "", "K", "M", "B", "T" };

    /// <summary>
    /// 숫자를 클리커용 문자열로 변환하여 반환해 주는 함수
    /// </summary>
    /// <param name="number">변환을 원하는 숫자</param>
    /// <param name="format">표시형식</param>
    /// <returns></returns>
    public static string ToClikerString(double number, string format)
    {
        // 숫자가 1000보다 작으면 굳이 특수한 형식으로 표시할 일이 없기 때문에
        // 원본 표시 형식대로 반환
        if(number < 1000)
        {
            return string.Format(format, number);
        }

        // 1000 단위를 세어 주는 카운트
        // 몇 번 1000으로 나눌 수 있는지 세는 것
        int unitCount = 0;
        while (number >= 1000)
        {
            number = number / 1000;    // number /= 1000;
            unitCount++;               // unitCount = unitCount + 1;
        }

        // 숫자 뒤에 붙일 영어 문자열
        string suffix = string.Empty;
        if(unitCount < _fixedUnits.Length)
        {
            suffix = _fixedUnits[unitCount];
        }
        else
        {
            unitCount -= _fixedUnits.Length;
            char first = (char)('a' + (unitCount / 26));
            char second = (char)('a' + (unitCount % 26));
            suffix = $"{first}{second}";
        }
        
        return string.Format(format, $"{number:N2}{suffix}");
    }
}
