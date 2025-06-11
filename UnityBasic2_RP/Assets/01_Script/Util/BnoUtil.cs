using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;

public class Util
{
    static Dictionary<float, WaitForSeconds> waitDic = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds WaitGet(float _waitSec)
    {
        if (waitDic.TryGetValue(_waitSec, out WaitForSeconds waitTime)) return waitTime;
        return waitDic[_waitSec] = new WaitForSeconds(_waitSec);
    }
    public static WaitForFixedUpdate waitFixed = new WaitForFixedUpdate();
}

public class BnoUtil : SingletonBehabiour<BnoUtil>
{
    // 돈 오르기
    public void ChangeValue(TextMeshProUGUI _TMP, int _before, int _after, float _time = 1)
    {
        StartCoroutine(CoinTextCoroutine(_TMP, _before, _after, _time));
    }

    IEnumerator CoinTextCoroutine(TextMeshProUGUI _TMP,int _before, int _after, float _time)
    {
        float time = 0;
        float addCoinValue = _after - _before;

        while (time < 1)
        {
            int nowCoint = _before + (int)(addCoinValue * time);
            _TMP.text = CoinText(nowCoint);
            time += _time * Time.fixedDeltaTime;
            yield return Util.waitFixed;
        }

        _TMP.text = CoinText(_after);
    }

    // n초후 행동하기
    public void WaitSec(Action _action, float _sec)
    {
        StartCoroutine(WaitSecCoroutine(_action, _sec));
    }

    IEnumerator WaitSecCoroutine(Action _action, float _sec)
    {
        yield return Util.WaitGet(_sec);
        _action();
    }

    // 다음 프레임
    public void WaitFrame(Action _action)
    {
        StartCoroutine(WaitFrameCoroutine(_action));
    }

    IEnumerator WaitFrameCoroutine(Action _action)
    {
        yield return Util.waitFixed;
        _action();
    }

    public string CoinText(int _value)
    {
        string result = string.Empty;
        if(1000000 <= _value)
        {
            float value = _value / 1000000f;
            result = string.Format("{0:0.0}M", value);
        }
        else if(1000 <= _value)
        {
            float value = _value / 1000f;
            result = string.Format("{0:0.0}k", value);
        }
        else
        {
            result = _value.ToString();
        }

        return result;
    }

    // Auto Click
    Coroutine cor_AutoClock;

    public void AutoClick(Button _Btn, Action _action)
    {
        if(_Btn.GetComponent<EventTrigger>() == null)
        {
            _Btn.gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry cklickOn = new EventTrigger.Entry();
        cklickOn.eventID = EventTriggerType.PointerDown;
        cklickOn.callback.AddListener((eventData) => BtnClickOn(_action));

        EventTrigger.Entry cklickOff = new EventTrigger.Entry();
        cklickOff.eventID = EventTriggerType.PointerUp;
        cklickOff.callback.AddListener((eventData) => BtnClickOff());

        _Btn.GetComponent<EventTrigger>().triggers.Add(cklickOn);
        _Btn.GetComponent<EventTrigger>().triggers.Add(cklickOff);
    }

    void BtnClickOn(Action _action)
    {
        _action();
        if (cor_AutoClock != null) StopCoroutine(cor_AutoClock);
        cor_AutoClock = StartCoroutine(AutoClickCoroutine(_action));
    }

    void BtnClickOff()
    {
        if (cor_AutoClock != null) StopCoroutine(cor_AutoClock);
    }

    IEnumerator AutoClickCoroutine(Action _action)
    {
        float scale = Time.timeScale;
        float time = 0;
        yield return Util.WaitGet(scale * 0.5f);
        while (time < 1)
        {
            _action();
            yield return Util.WaitGet(scale * 0.1f);
            time += 0.1f;
        }

        while (true)
        {
            _action();
            yield return Util.WaitGet(scale * 0.03f);
        }
    }
}
