using UnityEngine;
using UnityEngine.UI;

//������ �����ϴ� ������ �Ŵ���
public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
    }
    #endregion

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        currentScoreUI.text = $"���� ���� : {currentScore}";
        bestScoreUI.text = $"�ְ� ���� : {bestScore}";
    }

    //Inspector
    public Text currentScoreUI;
    public Text bestScoreUI;

    //Inner
    private int currentScore;
    private int bestScore;

    //���� ������ ���� ������Ƽ ����
    //���� ���� ���ٰ� ������ ����ó�� ������ �� �ִ�
    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            //1.���޹��� ���� ������ ������ ������
            currentScore = value;
            //2.UI�� �ش� ���� ����
            currentScoreUI.text = $"���� ���� : {currentScore}";

            //������ ������ �ְ� ������ �Ѿ��ٸ�
            if(currentScore > bestScore)
            {
                //�� ������ �ְ� ������ �����Ǹ�
                bestScore = currentScore;
                //UI�� ���ŵ�
                bestScoreUI.text = $"�ְ� ���� : {bestScore}";
                //���� �����Ϳ��� �� ��ġ�� ����
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
        }
    }
}
