using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSample : MonoBehaviour
{
    // ����Ƽ ������ ����Ŭ(life cycle)
    //����Ƽ������ ���۴ܰ���� ����ܰ���� �Լ��� ����
    //ex) Awake(���� ��), Start(����), Update(���� ��) ....

    //Ȱ��ȭ �Ǿ��� ���
    private void OnEnable()
    {
        Debug.Log("OnSceneLoaded�� ��ϵǾ����ϴ�.");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //��Ȱ��ȭ�� ���
    private void OnDisable()
    {
        Debug.Log("OnSceneLoaded�� �����Ǿ����ϴ�.");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"���� �ε�� ���� �̸��� {scene.name}�Դϴ�.");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            //���� �� ��带 �������� ������ LoadSceneMode�� Single�� ó����
            //Single ����� ������ ���� ����Ÿ���� ����
            SceneManager.LoadScene("BRP Sample Scene");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //LoadSceneMode�� Additive�� ���� ���� �� ���� ���ο� ���� �ߺ��ؼ� �ε��ϴ� ����
            //�翬�� �� �۾��� ������ ��� �⺻ ������Ʈ��(Mail Camera, Direction Light)� �� �ε�Ǳ� ������ �����ؾ� ��
            SceneManager.LoadScene("BRP Sample Scene", LoadSceneMode.Additive);
        }
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            StartCoroutine("LoadSceneC");

            //SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);
            //�񵿱���(async) �ε�

            //�Ϲ����� ���� �ε� �۾��� ���������� ó����
            //���� �ε��� �� �� ������ �ٸ� ��ҵ��� �۵����� �ʰ� ��
        }
    }

    IEnumerator LoadSceneC()
    {
        yield return SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);
    }
}
