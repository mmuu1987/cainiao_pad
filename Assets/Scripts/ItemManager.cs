using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Sprite> Sprites = new List<Sprite>();

    public List<int> levels = new List<int>();

    public GameObject PrefabGameObject;

    private Dictionary<int,ListItem> _dictionary = new Dictionary<int, ListItem>();

    public ListItem ListItem;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            //_dictionary.Add(i, ListItem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatItem()
    {
        
    }
#if UNITY_EDITOR_WIN
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0f, 0f, 100f, 100f), "test"))
        {
            CreatItem();
        }
    }
#endif
}
