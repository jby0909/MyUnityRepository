using System.Collections;
using System.IO;
using UnityEngine;

public class LoadAssetBundleManager : MonoBehaviour
{
    //��� �ۼ�
    string path = "Assets/Bundles/asset01";

    void Start()
    {
        StartCoroutine(LoadAsync(path));
    }

    IEnumerator LoadAsync(string path)
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));

        //������Ʈ�� ���� ������ ���
        yield return request;

        //������Ʈ�� ���� �޾ƿ� ���� ������ ������ ����
        AssetBundle bundle = request.assetBundle;

        //���޹��� ������ ���� ������ �ε�
        GameObject prefab = bundle.LoadAsset<GameObject>("BlueSphere");
        //LoadAssets<T>("�̸�");
        Instantiate(prefab);


    }

}
