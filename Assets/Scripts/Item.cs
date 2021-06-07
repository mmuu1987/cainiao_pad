using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Text Text;

    public Image image;

    private Image _parentImage;

    public RectTransform RectTransform { get; private set; }

    private void Awake()
    {
        _parentImage = this.GetComponent<Image>();

        RectTransform = _parentImage.rectTransform;

        this.GetComponent<Button>().onClick.AddListener((() =>
        {
            InternalactionManager.Instance.InputField_two.text = image.sprite.name;
        }));
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInfo(Sprite sprite)
    {
        image.sprite = sprite;
        image.SetNativeSize();
        Vector2 size = image.rectTransform.sizeDelta;
        RectTransform.sizeDelta = new Vector2(size.x+100, size.y+50);

    }
}
