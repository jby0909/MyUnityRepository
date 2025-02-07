using UnityEngine;
using UnityEngine.Audio;

//보드를 이용해서 오디오를 화면에서 표현하는 도구
//AudioUI 오브젝트에 연결
public class AudioBoardVisualizer : MonoBehaviour
{
    //보드 증가량
    public float minBoard = 50.0f;
    public float maxBoard = 500.0f;


    //사용할 오디오 클립
    public AudioClip audioClip;
    //사용할 오디오 소스
    public AudioSource audioSource;

    //오디오 믹서 추가
    public AudioMixer audioMixer;
    public Board[] boards;

    //스펙트럼용 samples
    public int samples = 64;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boards = GetComponentsInChildren<Board>();
        //GetComponentsInChildren<T>는 오브젝트에 연결된 자식 컴포넌트들을 가져오는 코드
        //현재 코드 기준으로는 Board의 배열

        //==게임 오브젝트를 만들어서 컴포넌트를 등록해주는 코드==
        //오디오 소스가 null이라면
        if(audioSource == null)
        {
            //"AudioSource" 게임 오브젝트를 생성하고, 해당 오브젝트에 AudioSource컴포넌트를 추가
            audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            
        }
        else
        {
            //존재하면 씬에서 찾아서 등록
            audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
            
        }
        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        //오디오믹서 그룹 중에서 "Master" 그룹을 찾아 적용
        
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
        //GetSpectrumData(samples, channel,FFTWindow);
        //samples = FFT(신호에 대한 주파수 영역)을 저장할 배열, 이 배열 값은 2의 제곱 수로 표현
        //채널은 최대 8개의 채널을 지원해주고 있음. 일반적으로는 0을 사용
        //FFTWindow는 샘플링 진행할 때 쓰는 값

        //보드 각각의 개수만큼 작업을 진행
        for(int i = 0; i < boards.Length; i++)
        {
            var size = boards[i].GetComponent<RectTransform>().rect.size;
            //보드 각각이 가지고 있는 사이즈를 얻어옴

            size.y = minBoard + (data[i] * (maxBoard - minBoard) * 3.0f);
            //여기서 3.0f는 막대에 대한 수치 보정값(막대가 너무 작게 움직여서 보기 좋게 바꾸는것뿐)

            boards[i].GetComponent<RectTransform>().sizeDelta = size;
            //sizeDelta는 부모를 기준으로 크기가 얼마나 큰지 작은지 나타낸 수치를 의미
        }
    }
}
