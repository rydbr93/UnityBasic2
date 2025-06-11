using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class SoundControl : ControlBase<SoundControl>
{
    [Header("Mixer")]
    [SerializeField] AudioMixer Mixer;

    [Header("BGM")]
    [SerializeField] AudioSource BGM;
    [AYellowpaper.SerializedCollections.SerializedDictionary("Name","SoundFile")]
    [SerializeField] AYellowpaper.SerializedCollections.SerializedDictionary<string, AudioClip> BGMData;
    Coroutine cor_ChangeBGM;

    public override void Open(PlayerData _pData)
    {
        base.Open(_pData);
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void Initialize()
    {
        base.Initialize();

        BGM.outputAudioMixerGroup = Mixer.FindMatchingGroups("BGM")[0];

        // 저장된 볼륨 불러오기
        // SetBGMVol(PData.Option.BGMVol);
        // SetSFXVol(PData.Option.SFXVol);
    }

    // BGM
    public void PlayBGM(string _name, float _changeTime = 0.6f)
    {
        if (BGMData.TryGetValue(_name, out AudioClip clip))
        {
            if (BGM.isPlaying && 0 < _changeTime)
            {
                if (cor_ChangeBGM != null) StopCoroutine(cor_ChangeBGM);
                cor_ChangeBGM = StartCoroutine(ChangeBGMCoroutine(clip, _changeTime));
            }
            else
            {
                BGM.clip = clip;
                BGM.Play();
            }
        }
    }

    IEnumerator ChangeBGMCoroutine(AudioClip _clip, float _changeTime)
    {
        float nowVol = BGM.volume;

        while (0 < nowVol)
        {
            nowVol -= 1 / _changeTime * Time.fixedDeltaTime;
            BGM.volume = nowVol;
            yield return Util.waitFixed;
        }

        nowVol = 0;
        BGM.volume = nowVol;
        BGM.clip = _clip;
        BGM.Play();

        while (nowVol < 1)
        {
            nowVol += 1 / _changeTime * Time.fixedDeltaTime;
            BGM.volume = nowVol;
            yield return Util.waitFixed;
        }

        nowVol = 1;
        BGM.volume = nowVol;
    }

    public void SetBGMVol(float _value)
    {
        _value = Mathf.Clamp(_value, 0, 1);
        Mixer.SetFloat("BGM", Mathf.Log10(_value) * 20);
        PData.Option.BGMVol = _value;
    }

    // SFX
    public void SetSFXVol(float _value)
    {
        _value = Mathf.Clamp(_value, 0, 1);
        Mixer.SetFloat("SFX", Mathf.Log10(_value) * 20);
        PData.Option.SFXVol = _value;
    }
}