using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, IPointerClickHandler {
    public GameObject LoginPanel;
    public GameObject MainPanel;
    public GameObject RegisterPanel;
    public GameObject MessagePanel;

    // Start is called before the first frame update
    void Start() {
        LoginPanel = GameObject.Find("LoginPanel");
        MainPanel = GameObject.Find("MainPanel");
    }

    public void  OnPointerClick(PointerEventData eventData) {
    }

    public InputField UserNameInput;
    public InputField PaswordInput;

    public void OnLoginButtonClick() {
        if (UserNameInput.text.Trim() == "123" && PaswordInput.text.Trim() == "123") {
            Debug.Log("登录成功!");
            LoginPanel.SetActive(false);
            SceneManager.LoadScene("Title");
        }
        else {
            Debug.Log("登录失败");
        }
    }

    public void OnBackButtonClick() {
        Application.Quit();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
