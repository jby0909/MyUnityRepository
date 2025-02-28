using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 dir;

    public GameObject explosionFactory;

    //OnEnable은 유니티에서 제공해주는 활성화 단계에 호출되는 함수(활성화 킬때마다 호출된다)
    private void OnEnable()
    {
        //적의 방향 설정
        int rand = Random.Range(0, 10); // 0 ~ 9 사이 랜던값 하나 가져옴

        //30% 확률
        if(rand < 3)
        {
            var target = GameObject.FindGameObjectWithTag("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize(); // 방향의 크기를 1로 설정
            //방향 벡터(Vector3.up, Vector3.down, Vector3.left ....)
        }
        else
        {
            dir = Vector3.down;
        }
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        //부딪힌 물체의 이름에 Bullet이 포함된다면(오브젝트 풀로 만들어질 이름은 Bullet(Clone)이런식이기 때문에)
        if(collision.gameObject.name.Contains("Bullet"))
        {
            Debug.Log("총알과 충돌");
            //해당 충돌체를 비활성화 처리
            collision.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("플레이어와 충돌");
            Destroy(collision.gameObject);
        }
        Debug.Log("자기자신 사라지기");
        gameObject.SetActive(false); // 적도 비활성화
    }

}
