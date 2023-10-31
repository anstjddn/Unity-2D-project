using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}



public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance { get { return instance; } }

    [SerializeField] Sound[] sfx;
    [SerializeField] Sound[] bgm;

    [SerializeField] public AudioSource bgmPlayer;
    [SerializeField] public AudioSource[] sfxPlayer;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public void PlayeBGM(string bgmName)
    {
        for(int i =0; i < bgm.Length; i++)
        {
            if(bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }
    public void StopBgm()
    {
        bgmPlayer.Stop();
    }
    public void PlaySFX(string p_sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (p_sfxName == sfx[i].name)
            {
                for (int j = 0; j < sfxPlayer.Length; j++)
                {
                    if (sfxPlayer[j].clip == null)
                    {
                        sfxPlayer[j].clip = sfx[i].clip;
                        sfxPlayer[j].Play();
                    }
                    // SFXPlayer���� ��� ������ ���� Audio Source�� �߰��ߴٸ� 
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfx[i].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }
                Debug.Log("��� ����� �÷��̾ ������Դϴ�.");
                return;
            }
        }
        Debug.Log(p_sfxName + " �̸��� ȿ������ �����ϴ�.");
        return;
    }
}
