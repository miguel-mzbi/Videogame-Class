using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBehav : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
    // onClick()
	public void ClickTest() {
        text.text = "Button Was Pressed";
    }

    // onValueChanged(Single)
    public void ValueChangeTest(float v) {
        text.text = "Value Changed";
    }
}
