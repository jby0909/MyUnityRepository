using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleDriveAssetBundle : MonoBehaviour
{

    private string imageFileURL = "https://docs.google.com/uc?export=download&id=1j4hmkoH656ivQwjkXSSsoeae-4-ucttd";

    
    public Image image;
    
    void Start()
    {
        StartCoroutine("DownLoadImage");
    }

    IEnumerator DownLoadImage()
    {
        //�ش� �ּ�(URL)�� ���� �ؽ�ó�� ������Ʈ ��û
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL);

        //������Ʈ�� �Ϸ�� ������ ���
        yield return www.SendWebRequest();

        //������Ʈ�� ����� �����̶��
        if(www.result == UnityWebRequest.Result.Success)
        {
            //�ٿ���� �ؽ�ó�� �����ϴ� �ڵ�
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            //Texture2D�� UI���� ���� ���� Sprite���·� ����
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);
            Debug.Log("�̹����� ���������� �����Խ��ϴ�.");
            image.sprite = sprite;
        }
        else
        {
            Debug.LogError("�̹����� �������� ���߽��ϴ�.");
        }
    }

}
