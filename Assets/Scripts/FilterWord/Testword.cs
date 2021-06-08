using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testword : MonoBehaviour {

    public InputField Input;

    public Button btn;

    public Text stateText;

	// Use this for initialization
	void Start ()
    {
        btn.onClick.AddListener(Click);
    }

    public void Click()
    {
        if(SystemUtil.IsInvaild(Input.text))
        {
            stateText.text = "有非法字符";
        }
        else
        {
            stateText.text = "";
        }
    }
}
