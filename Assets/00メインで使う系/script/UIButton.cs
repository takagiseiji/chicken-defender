using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    /*public Button putbutton;
    public Button levelupbutton;
    public Button withdrawalbutton;
    public Button dispatchbutton;
    public Button productionbutton;*/
    public GameObject uitop;
    public GameObject putui;
    public GameObject levelup;
    public GameObject withdrawal;
    public GameObject dispatch;
    public GameObject production;
    public GameObject UIreturn;
    GameObject nowUI;
    PlayerManager player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerManager>();
        putui.SetActive(false);
        levelup.SetActive(false);
        withdrawal.SetActive(false);
        dispatch.SetActive(false);
        production.SetActive(false);
        UIreturn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Put()
    {
        putui.SetActive(true);
        nowUI = putui;
        uitop.SetActive(false);
        UIreturn.SetActive(true);
    }
    public void Levelup()
    {
        levelup.SetActive(true);
        nowUI = levelup;
        uitop.SetActive(false);
        UIreturn.SetActive(true);
    }
    public void Withdrawal()
    {
        withdrawal.SetActive(true);
        nowUI = withdrawal;
        uitop.SetActive(false);
        UIreturn.SetActive(true);
    }
    public void Dispatch()
    {
        dispatch.SetActive(true);
        nowUI = dispatch;
        uitop.SetActive(false);
        UIreturn.SetActive(true);
    }
    public void Production()
    {
        production.SetActive(true);
        nowUI = production;
        uitop.SetActive(false);
        UIreturn.SetActive(true);
    }
    void TrunEnd()
    {
        //UIÇä«óùÇ∑ÇÈÇ‡ÇÃÇè¡Ç∑Ç©ñ¿Ç¢íÜ
    }
    public void Return()
    {
        uitop.SetActive(true);
        nowUI.SetActive(false);
    UIreturn.SetActive(false);
    }
}
