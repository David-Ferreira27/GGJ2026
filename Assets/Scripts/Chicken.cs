using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Chicken : MonoBehaviour, Possessable
{

    public GameObject mask;
    public List<GameObject> table_bones;
    public List<GameObject> ground_bones;
    private List<bool> attached_bones = new List<bool>(){false,false,false};
    public GameObject key3;
    public float var = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attached_bones[2] && !key3.activeSelf)
        {
            key3.SetActive(true);
            key3.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, 0);
        }

        if(attached_bones[0] && attached_bones[1])
        {
            //add code to open drawer for museum meber card
        }
    }

    public void Interact()
    {
        int can_dettach = -1;
        for(int i = 0; i < attached_bones.Count(); i++)
        {
            if(can_dettach == -1 && attached_bones[i]){can_dettach = i;}
        }
        if (can_dettach != -1)
        {
            attached_bones[can_dettach] = false;
            table_bones[can_dettach].SetActive(false);
            ground_bones[can_dettach].SetActive(true);
            ground_bones[can_dettach].transform.position = new Vector3(gameObject.transform.position.x-1, gameObject.transform.position.y, 0);
        }
    }

    public void AttachBone(int i)
    {
        if((i == 2 && !attached_bones[0] && !attached_bones[1]) || ((i == 0 || i == 1) && !attached_bones[2]))
        {
            mask.GetComponent<Player>().Despossess();
            attached_bones[i] = true;
            table_bones[i].SetActive(true);
            ground_bones[i].SetActive(false);
        }
    } 
}
