using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class InternalManager : MonoBehaviour
{
    public InputField InputField_one;

    public Button ConfirmBtn_one;

    public InputField InputField_two;

    public Button ConfirmButton_two;

    public InputField InputField_ip;

    public Button ConfirmButton_ip;

    public RectTransform IpStateTransform;

    public RectTransform OneStateTransform;

    public RectTransform TwoStateTransform;

    public Camera CapCamera;

    public RawImage RawImage;

    private int _month = 6;

    private int _day = 5;

    private int _curCount = 0;

    private string ip = null;
    // Start is called before the first frame update
    void Start()
    {

        ConfirmButton_ip.onClick.AddListener((() =>
        {
            string str = InputField_ip.text;

            bool isIp = GlobalSettings.ValidateIPAddress(str);

            if (isIp)
            {
                ip = str;
                IpStateTransform.gameObject.SetActive(false);
                OneStateTransform.gameObject.SetActive(true);
            }
            else
            {
                InputField_ip.text = "格式不正确，请重新输入";
            }
        }));

        ConfirmBtn_one.onClick.AddListener(() =>
        {
            string str = InputField_one.text;
            if (!string.IsNullOrEmpty(str))
            {
                Debug.LogError("第一状态输入的文字是：" + str);
                TwoStateTransform.gameObject.SetActive(true);
                OneStateTransform.gameObject.SetActive(false);
            }
        });


        ConfirmButton_two.onClick.AddListener(() =>
        {
            string str = InputField_two.text;
            if (!string.IsNullOrEmpty(str))
            {
                Debug.LogError("第二状态输入的文字是：" + str);
                MakePhoto(true);
            }
        });


        _curCount = HandleTime();
    }

    /// <summary>
    /// 获取天数，月份，来计算人的个数，虚拟人的数量
    /// </summary>
    /// <returns></returns>
    private int HandleTime()
    {
        int month = DateTime.Now.Month;

        int v1 = month-_month;
        if (v1 <= 0) v1 = 0;

        int day = DateTime.Now.Day;

        int v2 = day - _day;

        if (v2 <= 0) v2 = 0;

        int value = (v1 * 30 + v2)*10000;

        return value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public string MakePhoto(bool openIt)
    {
        int resWidth = 1920;
        int resHeight = 1080;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        
        {
            this.CapCamera.targetTexture = rt;
            this.CapCamera.Render();
            this.CapCamera.targetTexture = null;
        }
        RenderTexture prevActiveTex = RenderTexture.active;
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0f, 0f, (float)resWidth, (float)resHeight), 0, 0);
        screenShot.Apply();
        RenderTexture.active = prevActiveTex;
        Object.Destroy(rt);
        //base.StartCoroutine(NetManager.Instance.PostPictureToServer(screenShot));
        RawImage.gameObject.SetActive(true);
        RawImage.texture = screenShot;


        return null;
    }

}
