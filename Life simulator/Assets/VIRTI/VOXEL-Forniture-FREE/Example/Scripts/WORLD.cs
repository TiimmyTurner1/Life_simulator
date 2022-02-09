using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WORLD : MonoBehaviour {
    public float timeVel = 1;
    public GameObject[] dayObjs;
    public GameObject[] nightObjs;
    public Renderer cloud;
    public Renderer stars; 
    public Material daySkybox;
    public Material nightSkybox;
    public Transform sun;
    public float enviromentLightDay = 1;
    public float enviromentLightNight = 0;

    public GameObject menu;

    bool day;

    [Range(0, 24)]
    public float timeOfDay;

	void Start () {
        timeOfDay = 6;
        cloud.gameObject.SetActive(true);
        stars.gameObject.SetActive(true);

    }
	
	void Update () {
        timeOfDay += Time.deltaTime*timeVel;
        timeOfDay = timeOfDay % 24;

        sun.localRotation = Quaternion.Euler(((timeOfDay / 24) * 360)-90, 170f, 0);

        if (timeOfDay > 6 && !day)
        {
            foreach (GameObject obj in dayObjs)
                obj.SetActive(true);
            foreach (GameObject obj in nightObjs)
                obj.SetActive(false);            
            day = true;
        }        

        if (timeOfDay > 18 && day)
        {
            foreach (GameObject obj in dayObjs)
                obj.SetActive(false);
            foreach (GameObject obj in nightObjs)
                obj.SetActive(true);
            day = false;
        }

        cloud.GetComponent<Animator>().SetFloat("Vel", timeVel);

        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(daySkybox.GetColor("_Tint"), nightSkybox.GetColor("_Tint"), Mathf.Abs((timeOfDay/12)-1))); 
        RenderSettings.ambientIntensity = Mathf.MoveTowards(enviromentLightDay, enviromentLightNight, Mathf.Abs((timeOfDay / 12) - 1));
        Color cor = cloud.material.color;
        if(timeOfDay > 5 && timeOfDay < 17 && cor.a < 1)
            cor.a += (Time.deltaTime*timeVel) / 2;
        if ((timeOfDay > 17 && timeOfDay < 24 || timeOfDay > 0 && timeOfDay < 5) && cor.a > 0)
            cor.a -= (Time.deltaTime * timeVel) / 2;
        cloud.material.color = cor;
        cor = stars.material.color;
        if (timeOfDay > 5 && timeOfDay < 17 && cor.a > 0)
            cor.a -= (Time.deltaTime * timeVel) / 2;
        if ((timeOfDay > 17 && timeOfDay < 24 || timeOfDay > 0 && timeOfDay < 5) && cor.a < 1)
            cor.a += (Time.deltaTime * timeVel) / 2;
        stars.material.color = cor;

        if (Input.GetKeyDown(KeyCode.F1))
            SetMorning();
        if (Input.GetKeyDown(KeyCode.F2))
            SetDay();
        if (Input.GetKeyDown(KeyCode.F3))
            SetNight();
        if (Input.GetKeyDown(KeyCode.F4))
            StopPlayTime();
        if (Input.GetKeyDown(KeyCode.F5))
            SlowerTime();
        if (Input.GetKeyDown(KeyCode.F6))
            FasterTime();
        if (Input.GetKeyDown(KeyCode.F7))
            DefaultTime();
        if (Input.GetKeyDown(KeyCode.Tab))
            menu.SetActive(!menu.activeInHierarchy);
    }

    public void SetMorning()
    {
        timeOfDay = 6.1f;
    }

    public void SetDay()
    {
        timeOfDay = 11f;
    }

    public void SetNight()
    {
        timeOfDay = 18.1f;
    }

    public void StopPlayTime()
    {
        if (timeVel > 0)
            timeVel = 0;
        else
            timeVel = 1;
    }

    public void FasterTime()
    {
        if (timeVel < 10)
            timeVel += 1;
    }     

    public void SlowerTime()
    {
        if (timeVel > 0)
        {
            if (timeVel > 1)
                timeVel -= 1;
            else
                timeVel -= 0.25f;
        }
    }

    public void DefaultTime()
    {
        timeVel = 1;
    }
}

