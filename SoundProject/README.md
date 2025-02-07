## Unity BootCamp 20025-02-07 Sound and Vidio


### 오디오 소스(Audio Source)
-씬에서 오디오 클립(AudioClip)을 재생하는 도구   
-재생을 하기 위해서는 오디오 리스너(Audio Listener)나 오디오 믹서(Audio Mixer)가 필요   
-믹서는 따로 만들어야 하며, 오디오 리스너는 보통 메인 카메라에 붙어있음   


##### Audio Source컴포넌트의 프로퍼티
![캡처](https://github.com/user-attachments/assets/1976ef1b-49e9-4e68-a40b-d5f551d0fae1)


|프로퍼티명|내용|
|:-------------|:-------------------------------|
|Audio Resource|재생을 진행할 사운드 클립에 대한 등록|
|Output|기본적으로는 오디오 리스너에 직접 출력됨(None) <br> 만약 만든 오디오 믹서가 있다면 그 믹서를 통해 출력함|
|Mute|체크 시 음소거 처리|
|Bypass Effects|오디오 소스에 적용되어 있는 필터 효과를 분리|
|Bypass Listener Effect|리스너 효과 ON/OFF|
|Bypass Reverb Zones|리버브 존 ON/OFF|
|Play On Awake|해당 옵션을 체크했을 경우 씬이 실행되는 시점에 사운드 재생이 처리 됨 <br> 해당 기능 비활성화 시 스크립트를 통해 Play()명령을 진행해 사운드를 재생|
|Loop|옵션 활성화 시 재생이 끝날 때 오디오 클립을 반복|
|Priority|오디오 소스의 우선순위 <br> 0 = 최우선 <br> 128 = 기본 <br> 256 = 최하위|
|Volume|리스너 기준으로 거리 기준 소리에 대한 수치 <br> 컴퓨터 내의 소리를 재생하는 여러 가지 요소 중 하나를 제어|
|Pitch|재생 속도가 빨라지거나 느려질 때의 피치 변화량 <br> 1은 일반 속도 <br> 최대 수치 3 |
|Stereo Pan|소리 재생 시 좌우 스피커 간의 소리 분포를 조절 기능 <br> -1 : 왼쪽 스피커 <br> 0 : 양쪽 균등 <br> 1 : 오른쪽 스피커|
|Spatial Blend|0 : 사운드가 거리와 상관없이 일정하게 들어감(2D 사운드) <br> 1 : 사운드가 사운드 트는 도구의 거리에 따라 변화(3D 사운드)|
|Reverb Zon mix|리버브 존에 대한 출력 신호 양을 조절 <br> 0 : 영향을 받지 않음 <br> 1 : 오디오 소스와 리버브 존 사이의 신호를 최대치(설정한대로 넣겠다는 의미) <br> 1.1 : 10db 증폭 <br> *리버브 존 : 오디오 리슨너의 위치에 따라 잔향 효과를 설정하는 도구|
|3D Sound Settings|거리에 따른 사운드 설정들|


*3D Sound Settings
|프로퍼티명|내용|
|:-------------|:-------------------------------|
|Doppler Level|거리에 따른 사운드 높낮이 표현 <br> 0 : 효과 없음|
|Spread|사운드가 퍼지는 각도(0~360) <br>	0 : 한 점에서 사운드가 나오는 방식 <br> 360 : 모든 방향으로 균일하게 퍼지는 방식|
|Rolloff Mode|그래프 설정 <br> 1.로그 그래프 : 가까우면 사운드가 크고 멀수록 점점 빠르게 사운드가 작아짐 <br> 2.선형 그래프 : 거리에 따라 일정하게 사운드가 변화하는 구조 <br> 3.커스텀 그래프 : 직접 조절하는 영역|

-----------------------------------------------------------------------------------------------------------------
##### 실습 내용
*Audio Source 연결하기   
1)인스펙터에서 직접 연결하는경우 : public으로 선언
```cs
public AudioSource audioSourceBGM;
```
2)해당 스크립트를 컴포넌트로 가지고 있는 객체가 자체적으로 오디오 소스를 가지고 있는 경우
```cs
private AudioSource own_audioSource;

void Start()
{
  own_audioSource = GetComponent<AudioSource>();
}
```
3)Scene에서 찾아서 연결하는 경우 
```cs
public AudioSource audioSoundSFX;

void Start()
{
  audioSoundSFX = GameObject.Find("SFX").GetComponent<AudioSource>();
  //GameObject.Find()는 씬에서 찾은 gameObject를 return.   
  //GameObject이기 때문에 GetComponent<T>를 이어 작성함으로써 오브젝트가 가진 컴포넌트의 값을 return함   
  //따라서 이 결과물은 AudioSource가 됨
}
```

*AudioSourceSample 스크립트 작성(AudioSource연결 및 AudioClip 등록, 재생)
```cs
public class AudioSourceSample : MonoBehaviour
{
    public AudioSource audioSourceBGM;
    public AudioSource audioSoundSFX;

    public AudioClip bgm; //오디오 클립에 대한 연결

    

    void Start()
    {
        
        audioSoundSFX = GameObject.Find("SFX").GetComponent<AudioSource>();

        audioSourceBGM.clip = bgm;
        //오디오 소스의 클립을 bgm으로 설정함

        audioSoundSFX.clip = Resources.Load("Explosion") as AudioClip;
        //Resources.Load()는 리소스 폴더에서 오브젝트를 찾아 로드하는 기능
        //이때 받아오는 값은 Object이므로, as 클래스명을 통해 해당 데이터가 어떤 형태인지 표현해주면 그 형태로 받아오게 됨

        audioSoundSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;
        //리소스 로드 시 경로가 정해져 있다면 폴더명/파일명 으로 작성
        //리소스 로드 시 작성하는 이름에는 확장자명(ex).json, .avi)를 작성하지 않음

        UnityWebRequest의 GetAudioClip 기능 활용
        StartCoroutine("GetAudioClip"); 

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


}
```


<hr>
### 오디오 믹서(Audio Mixer)
오디오 소스에 대한 제어, 균형, 조정을 제공하는 도구

-믹서 만드는 방법   
Create -> Audio -> AudioMixer를 통해 Audio Group을 생성   
*최초 생성 시 Master 그룹이 존재함

![캡처2](https://github.com/user-attachments/assets/637a780d-7106-4aee-a9e7-21b8ffad1fa1)




<hr>

### 유니티 레코더(Unity Recorder)      
유니티 내부에서 녹화하는 기능      
1. 설치   
  Package Manager -> Unity Registry -> Recorder

2. 사용하기   
   Window -> General -> Recorder -> Recorder Window
   |프로퍼티명|내용|
   |:-------------|:-------------------------------|
   |Exist Play Mode|체크되어 있으면 녹화 끝나면 플레이도 끝|
   |Recording Mode|Manual(사용자 직접 녹화 설정 종료 가능. 주로 사용)|
   |Playback|녹화 중 일정 프레임 속도 유지|
   |TargetFPS|녹화 FPS지정|
   |Cap|설정한 FPS를 넘지 않도록 제한|

