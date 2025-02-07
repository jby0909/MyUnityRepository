using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSourceSample : MonoBehaviour
{
    //0) �ν����Ϳ��� ���� �����ϴ� ���
    public AudioSource audioSourceBGM;

    //1) AudioSourceSample ��ü�� ��ü������ ����� �ҽ��� ������ �ִ� ���
    //private AudioSource own_audioSource;

    //2) ������ ã�Ƽ� �����ϴ� ���
    //3) Resources.Load() ����� �̿��� ���ҽ� ������ �ִ� ����� �ҽ� Ŭ���� �޾ƿ���
    public AudioSource audioSoundSFX;

    public AudioClip bgm; //����� Ŭ���� ���� ����

    bool IsPause;

    void Start()
    {
        //1)�� ��� GetComponent<T>�� ���� �ش� ��ü�� ������ �ִ� ����� �ҽ� ���� ����
        //own_audioSource = GetComponent<AudioSource>();

        //2)�� ���  GameObject.Find()Ȱ��
        //GameObject.Find()�� ������ ã�� gameObject�� return�ϴ� ����� ������ ����. ��, �� ���� gameObject��
        //GameObject�̱� ������ GetComponent<T>�� �̾� �ۼ������ν� ������Ʈ�� ���� ������Ʈ�� ���� return��
        //���� �� ������� AudioSource�� ��
        audioSoundSFX = GameObject.Find("SFX").GetComponent<AudioSource>();

        audioSourceBGM.clip = bgm;
        //����� �ҽ��� Ŭ���� bgm���� ������

        audioSoundSFX.clip = Resources.Load("Explosion") as AudioClip;
        //Resources.Load()�� ���ҽ� �������� ������Ʈ�� ã�� �ε��ϴ� ���
        //�̶� �޾ƿ��� ���� Object�̹Ƿ�, as Ŭ�������� ���� �ش� �����Ͱ� � �������� ǥ�����ָ� �� ���·� �޾ƿ��� ��

        audioSoundSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;
        //���ҽ� �ε� �� ��ΰ� ������ �ִٸ� ������/���ϸ� ���� �ۼ�
        //���ҽ� �ε� �� �ۼ��ϴ� �̸����� Ȯ���ڸ�(ex).json, .avi)�� �ۼ����� ����

        //UnityWebRequest�� GetAudioClip ��� Ȱ��
        //StartCoroutine("GetAudioClip"); 

        //����� �ҽ� ��ũ��Ʈ ���
        //audioSourceBGM.Play(); //Ŭ���� �����ϴ� ����
        //audioSourceBGM.Pause(); //�Ͻ� ���� ���
        //audioSoundSFX.PlayOneShot(bgm); //Ŭ�� �ϳ��� �Ѽ��� �÷��̸� ����
        //audioSourceBGM.Stop(); // ����� Ŭ�� ��� ����
        //audioSourceBGM.UnPause(); // �Ͻ����� ����
        //audioSourceBGM.PlayDelayed(1.8f); //1�� �ڿ� ���
    }

    
    
    IEnumerator GetAudioClip()
    {
        UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip("file:///" + Application.dataPath + "/Audio/" + "Explosion" + ".wav",AudioType.WAV);

        yield return uwr.SendWebRequest(); // ����

        var new_clip = DownloadHandlerAudioClip.GetContent(uwr);
        //���� ��θ� ������� �ٿ�ε� ����

        audioSourceBGM.clip = new_clip; //Ŭ�� ���
        audioSourceBGM.Play(); //�÷���
    }

    public void BGMPlay()
    {
        audioSourceBGM.Play();
        Debug.Log("��� ����");
    }

    public void BGMPause()
    {
        if(IsPause)
        {
            audioSourceBGM.UnPause();
            IsPause = false;
            Debug.Log("��� �̾ ���");
        }
        else
        {
            audioSourceBGM.Pause();
            IsPause = true;
            Debug.Log("��� �Ͻ�����");
        }
        
    }

    public void BGMStop()
    {
        audioSourceBGM.Stop();
        Debug.Log("��� ����");
    }
}
