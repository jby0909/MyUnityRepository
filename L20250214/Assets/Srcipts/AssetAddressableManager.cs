using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetAddressableManager : MonoBehaviour
{
    //AssetReference�� Ư�� Ÿ���� �������� �ʰ� ��巹������ ���ҽ��� �����ϰ� ��
    //AssetReferenceGameObject�� ��巹���� ���ҽ� �߿��� GameObject�� �ش��ϴ� ���� ����
    //AssetReferenceT�� ���׸��� �̿��� Ư�� ������ ��巹���� ���ҽ��� ����
    public AssetReferenceGameObject capsule;

    public GameObject go = new GameObject();

    private void Start()
    {
        StartCoroutine("Init");
    }

    private IEnumerator Init()
    {
        var init = Addressables.InitializeAsync();
        yield return init;
    }

    public void OnCreateButtonEnter()
    {
        capsule.InstantiateAsync().Completed += (obj) => 
        {
            go = obj.Result;
        };
    }

    public void OnReleaseButtonEnter()
    {
        Addressables.ReleaseInstance(go); //����
    }
}
