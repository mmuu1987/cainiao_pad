using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItem : MonoBehaviour
{

    public List<Item> items = new List<Item>();

   

    public float Speed = -1f;

    public GameObject PrefabGameObject;

    
    
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("屏幕分辨率为："+Screen.width+"  "+Screen.height);
        AddItem();

    }

    // Update is called once per frame
    void Update()
    {
       

        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];

            Vector2 pos = item.RectTransform.anchoredPosition;

            Vector2 newPos = new Vector2(pos.x + Speed, pos.y);

            if (Speed > 0)
            {
                if (newPos.x >= 1280f)
                {

                    Item endItem = items[items.Count - 1];

                    Vector2 posEnd = endItem.RectTransform.anchoredPosition;

                    Vector2 size = item.RectTransform.sizeDelta;

                    item.RectTransform.anchoredPosition = new Vector2(posEnd.x - size.x - 100f, posEnd.y);

                    items.Remove(item);

                    items.Add(item);
                    break;
                }

                item.RectTransform.anchoredPosition = new Vector2(pos.x + Speed, pos.y);
            }
            else
            {
                if (newPos.x <= -1280f)
                {

                    Item endItem = items[items.Count - 1];

                    Vector2 posEnd = endItem.RectTransform.anchoredPosition;

                    Vector2 size = item.RectTransform.sizeDelta;

                    item.RectTransform.anchoredPosition = new Vector2(posEnd.x + size.x + 100f, posEnd.y);

                    items.Remove(item);

                    items.Add(item);
                    break;
                }

                item.RectTransform.anchoredPosition = new Vector2(pos.x + Speed, pos.y);
            }
        }
       

       
    }

    /// <summary>
    /// 检测范围
    /// </summary>
    private void CheckRange()
    {
        bool isMoveLeft = Speed > 0;

    }
    public void AddItem()
    {

        List<Item> temps = new List<Item>();
        for (int i = 0; i < 4; i++)
        {
            Item item = Instantiate(PrefabGameObject).GetComponent<Item>();

            item.transform.parent = this.transform;

            int index = Random.Range(0, InternalactionManager.Instance.Sprites.Count);

            Sprite sprite = InternalactionManager.Instance.Sprites[index];

            item.SetInfo(sprite);

            temps.Add(item);

        }


        bool isMoveLeft = Speed < 0;


        foreach (Item item in temps)
        {
            item.RectTransform.pivot = isMoveLeft ? new Vector2(1, 0.5f) : new Vector2(0f, 0.5f);
            if (items.Count > 0)
            {
                Item endItem = items[items.Count - 1];

                
                Vector2 pos = endItem.RectTransform.anchoredPosition;

                Vector2 size = item.RectTransform.sizeDelta;

                item.RectTransform.anchoredPosition = isMoveLeft ? new Vector2(pos.x + size.x + 100f, pos.y) : new Vector2(pos.x - size.x - 100f, pos.y);
                
            }
            else
            {
                item.RectTransform.anchoredPosition = Vector2.zero;
            }
            items.Add(item);
        }
       
    }
}
