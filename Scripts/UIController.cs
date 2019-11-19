using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class UIController : MonoBehaviour
{
    [SerializeField] public SettingsPopup Nice;
    [SerializeField] public SettingsPopup King;
    [SerializeField] public SettingsPopup Excell;
    [SerializeField] public SettingsPopup Brave;
    [SerializeField] public SettingsPopup settingsPopup;
    private int randomimag;
    private Animator anim;
    private int achiv;

    public void OnCloseSetting()
    {
        settingsPopup.Close();
        Brave.Close();
        Excell.Close();
        King.Close();
        Nice.Close();
    }


    void Start()
    {
        settingsPopup.Close();
        Brave.Close();
        Excell.Close();
        King.Close();
        Nice.Close();
    }

    


    public void OnOpenSettings()
    {
        settingsPopup.Open();
        // Debug.Log("open settings");

    }
public void OnOpenNi()
    {
        Nice.Open();
    }
    public void OnOpenKing()
    {
                   King.Open();
             }
    //
    public void OnOpenBrave() {
                             Brave.Open();
                }

    

    public void OnOpenExcel() {
        Excell.Open();
    }

 void Update()
    {
        // scoreLabel.text = Time.realtimeSinceStartup.ToString();
       

    }
}