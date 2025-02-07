using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSourceSample : MonoBehaviour
{
    //0) 인스펙터에서 직접 연결하는 경우
    public AudioSource audioSourceBGM;

    //1) AudioSourceSample 객체가 자체적으로 오디오 소스를 가지고 있는 경우
    //private AudioSource own_audioSource;

    //2) 씬에서 찾아서 연결하는 경우
    //3) Resources.Load() 기능을 이용해 리소스 폴더에 있는 오디오 소스 클립을 받아오기
    public AudioSource audioSoundSFX;

    public AudioClip bgm; //오디오 클립에 대한 연결

    bool IsPause;

    void Start()
    {
        //1)의 경우 GetComponent<T>를 통해 해당 객체가 가지고 있는 오디오 소스 연결 가능
        //own_audioSource = GetComponent<AudioSource>();

        //2)의 경우  GameObject.Find()활용
        //GameObject.Find()는 씬에서 찾은 gameObject를 return하는 기능을 가지고 있음. 즉, 이 값은 gameObject임
        //GameObject이기 때문에 GetComponent<T>를 이어 작성함으로써 오브젝트가 가진 컴포넌트의 값을 return함
        //따라서 이 결과물은 AudioSource가 됨
        audioSoundSFX = GameObject.Find("SFX").GetComponent<AudioSource>();

        audioSourceBGM.clip = bgm;
        //오디오 소스의 클립을 bgm으로 설정함

        audioSoundSFX.clip = Resources.Load("Explosion") as AudioClip;
        //Resources.Load()는 리소스 폴더에서 오브젝트를 찾아 로드하는 기능
        //이때 받아오는 값은 Object이므로, as 클래스명을 통해 해당 데이터가 어떤 형태인지 표현해주면 그 형태로 받아오게 됨

        audioSoundSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;
        //리소스 로드 시 경로가 정해져 있다면 폴더명/파일명 으로 작성
        //리소스 로드 시 작성하는 이름에는 확장자명(ex).json, .avi)를 작성하지 않음

        //UnityWebRequest의 GetAudioClip 기능 활용
        //StartCoroutine("GetAudioClip"); 

        //오디오 소스 스크립트 기능
        //audioSourceBGM.Play(); //클립을 실행하는 도구
        //audioSourceBGM.Pause(); //일시 정지 기능
        //audioSoundSFX.PlayOneShot(bgm); //클립 하나를 한순간 플레이를 진행
        //audioSourceBGM.Stop(); // 오디오 클립 재생 중지
        //audioSourceBGM.UnPause(); // 일시정지 해제
        //audioSourceBGM.PlayDelayed(1.8f); //1초 뒤에 재생
    }

    
    
    IEnumerator GetAudioClip()
    {
        UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip("file:///" + Application.dataPath + "/Audio/" + "Explosion" + ".wav",AudioType.WAV);

        yield return uwr.SendWebRequest(); // 전달

        var new_clip = DownloadHandlerAudioClip.GetContent(uwr);
        //받은 경로를 기반으로 다운로드 진행

        audioSourceBGM.clip = new_clip; //클립 등록
        audioSourceBGM.Play(); //플레이
    }

    public void BGMPlay()
    {
        audioSourceBGM.Play();
        Debug.Log("브금 실행");
    }

    public void BGMPause()
    {
        if(IsPause)
        {
            audioSourceBGM.UnPause();
            IsPause = false;
            Debug.Log("브금 이어서 재생");
        }
        else
        {
            audioSourceBGM.Pause();
            IsPause = true;
            Debug.Log("브금 일시정지");
        }
        
    }

    public void BGMStop()
    {
        audioSourceBGM.Stop();
        Debug.Log("브금 정지");
    }
}
