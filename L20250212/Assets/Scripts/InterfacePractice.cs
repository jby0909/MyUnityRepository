using UnityEngine;
using UnityEngine.EventSystems;



public delegate void ClickEventExample();

public class InterfacePractice : MonoBehaviour, IPointerClickHandler
{
    ClickEventExample clickEventExample;

    public void OnPointerClick(PointerEventData eventData)
    {
        clickEventExample += new ClickEventExample(MoveRight);
        clickEventExample();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 10;
    }

    public void MoveUp()
    {
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 10;
    }


    public void AddMoveUp()
    {
        clickEventExample += MoveUp;
    }

    
}
