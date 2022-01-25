using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cam : MonoBehaviour {
    public GameObject uiInteract;
    public LayerMask layerInteractive;

    float recuoInteract;

    void Start () {
		
	}
	
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5, layerInteractive))
        {
            Collider[] cols = Physics.OverlapSphere(hit.point, 0.01f, layerInteractive);
            if(cols.Length > 0)
            {
                Interactable inte = cols[cols.Length - 1].GetComponent<Interactable>();               
                if (inte)
                {
                    uiInteract.SetActive(true);
                    uiInteract.GetComponentInChildren<Text>().text = inte.objName;
                    recuoInteract = 0.1f;
                    if (Input.GetButtonDown("Fire1"))
                        inte.Interact();
                }
            }
        }
        if(recuoInteract > 0)
        {
            if (recuoInteract > 0.05f)
                recuoInteract -= Time.deltaTime;
            else
            {
                uiInteract.SetActive(false);
                recuoInteract = 0;
            }
        }
	}
}
