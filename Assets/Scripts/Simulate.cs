using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Simulate : MonoBehaviour
{
    private UIManager uiManager;

    [SerializeField] GameObject ball;
    [SerializeField] Vector3[] movPath;
    public int steps;

    float gr = -9.81f;
    float vox, hmax, tUp, tTotal, dx, voy, vy ,dv;
    float estimation;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Calculate(float vo, float angle)
    {
        angle *= Mathf.Deg2Rad;
        vox = vo * Mathf.Cos(angle);
        voy = vo * Mathf.Sin(angle);

        hmax = -(Mathf.Pow(voy, 2)) / (2 * gr);
        tUp = -voy / gr;
        tTotal = 2 * tUp;
        dx = vox * tTotal;
        //Debug.Log($"Dist X: {dx} Hmax: {hmax} time: {tTotal}");
    }
    public void StartSimulate(float vInit, float angle,float estim)
    {
        estimation = estim;
        ///Cosas magníficas
        Calculate(vInit, angle);
        
        float partTime = tTotal/steps;
        for(int i = 1; i < steps+1; i++)
        {
            float y = voy *partTime *i - 4.9f * Mathf.Pow(partTime*i,2);
            float x = vox *(partTime * i);
            movPath[i - 1] = new Vector3(x,y,0);
        }
        uiManager.DataSimulation(dx,hmax,tTotal);
        Movement();
    }

    public void Movement()
    {
        ball.transform.DOPath(movPath,2).OnComplete(()=> EndSimulation());
    }

    public void EndSimulation()
    {
        float variation = (Mathf.Abs(dx-estimation) / dx)*100;
        Debug.Log(variation);
        if(variation < 5f)
        {
            uiManager.WinState();
        }
        else uiManager.LoseState();
    }

}
