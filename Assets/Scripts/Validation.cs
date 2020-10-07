using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Validation : MonoBehaviour
{

    [SerializeField] TMPro.TMP_InputField velInitInput;
    [SerializeField] TMPro.TMP_InputField angleInput;
    [SerializeField] TMPro.TMP_InputField estimInput;
    [SerializeField] Button simButton;

    UIManager uiManager;
    Simulate simulate;

    float velInit, angle, estim;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        simulate = FindObjectOfType<Simulate>();
        simButton.interactable = false;
    }

    public void GetValues()
    { 
        float.TryParse(velInitInput.text,out velInit);
        float.TryParse(angleInput.text, out angle);
        float.TryParse(estimInput.text, out estim);
        Validate();
    }

    private void Validate()
    {
        if(velInitInput.text!=null && angleInput.text!=null && estimInput.text != null)
        {
            if(velInit>0 && angle>=0 && angle<=90 &&estim>0)
            {
                ///Simulate
                uiManager.ShowAlert(false);
                simButton.interactable = true;
            }
            else
            {
                uiManager.ShowAlert(true,"Ángulo entre 0 y 90 - Velocidad > 0");
            }
        }
        else
        {
            ///DATOS NO INTRODUCIDOS
            uiManager.ShowAlert(true,"Introduce datos");
        }
    }


    public void Simulate()
    {
        uiManager.HidePanelData();
        simulate.StartSimulate(velInit,angle,estim);
    }

}
