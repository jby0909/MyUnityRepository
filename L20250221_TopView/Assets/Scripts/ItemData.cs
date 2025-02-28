using UnityEngine;

public enum ItemType
{
    arrow, key, life, coin, diamonds
}

public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int arrow_count = 5;
    public int key_count = 1;
    public int coin_count = 1000;
    public int dia_count = 10;
    public int arrangeId = 0; //식별 값

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //타입에 따라 처리할 내용
            switch(type)
            {
                case ItemType.arrow:
                    ArrowShoot shoot = collision.gameObject.GetComponent<ArrowShoot>();
                    ItemKeeper.hasArrows += arrow_count;
                    UIManager.ArrowText.text = $"Arrow : {ItemKeeper.hasArrows}";
                    break;
                case ItemType.key:
                    ItemKeeper.hasKeys += key_count;
                    break;
                case ItemType.life:
                    if(PlayerController.hp < 10)
                    {
                        PlayerController.hp++;
                        PlayerController.SetHpBar();
                        UIManager.HPText.text = $"HP : {PlayerController.hp}";
                    }
                    break;
                case ItemType.coin:
                    ItemKeeper.hasCoin += coin_count;
                    UIManager.GoldText.text = $"Gold : {ItemKeeper.hasCoin}";
                    break;
                case ItemType.diamonds:
                    ItemKeeper.hasDia += dia_count;
                    
                    break;
            }

            //아이템 획득 시의 연출
            //1.아이템이 공통적으로 가지고 있는 콜라이더를 비활성화
            GetComponent<CircleCollider2D>().enabled = false;
            //2.아이템이 공통적으로 가지고 있는 리지드바디를 통해 위로 튀어오르는 연출을 표현
            var item_rbody = GetComponent<Rigidbody2D>();
            item_rbody.gravityScale = 2.5f;
            item_rbody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            Destroy(gameObject, 0.5f);
        }
    }
}
