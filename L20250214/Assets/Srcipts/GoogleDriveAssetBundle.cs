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
        //해당 주소(URL)을 통해 텍스처를 리퀘스트 요청
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL);

        //리퀘스트가 완료될 때까지 대기
        yield return www.SendWebRequest();

        //리퀘스트의 결과가 성공이라면
        if(www.result == UnityWebRequest.Result.Success)
        {
            //다운받은 텍스처를 적용하는 코드
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            //Texture2D를 UI에서 쓰기 위해 Sprite형태로 변경
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);
            Debug.Log("이미지를 성공적으로 가져왔습니다.");
            image.sprite = sprite;
        }
        else
        {
            Debug.LogError("이미지를 가져오지 못했습니다.");
        }
    }

}
