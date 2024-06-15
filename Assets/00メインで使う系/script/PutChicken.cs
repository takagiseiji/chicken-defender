using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutChicken : MonoBehaviour
{
    public PlayerManager player;
    public GameObject bchicken;
    public GameObject schicken;
    //public LayerMask spawnpoint;
   // public LayerMask ground;
    public Chicken chicken;
    public Button bchickenbutton;
    public Button schickenbutton;
    public GameObject selectchicken;
    public GameObject nochicken;
    public bool nochickentrue = false;
    float nochickentime = 0;

    public GameObject checkground;

    //ひとまず置くことはできるようになった
    //重ね置きができるから治す　たぶんその地面の子オブジェクトを確認して居なければにすればいいと思う
    // Start is called before the first frame update
    void Start()
    {
        nochicken.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (player.chicken >= 1)
            {
                Debug.Log("put1");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("ground"))
                    {
                        int count = hit.collider.transform.childCount;
                        if (count == 0)
                        {
                            if (selectchicken == schicken)
                            {
                                Vector3 vec = hit.collider.gameObject.transform.position;
                                Transform spawn = hit.collider.gameObject.transform;
                                //vec.y += 1;
                                spawn.position = vec;
                                Debug.Log("put2");
                                selectchicken = Instantiate(selectchicken, spawn);
                                selectchicken = schicken;
                            }
                            else
                            {
                                return;
                            }
                        }

                    }
                    else if (hit.collider.CompareTag("hground"))
                    {
                        int count = hit.collider.transform.childCount;
                        if (count == 0)
                        {
                            if (selectchicken == bchicken)
                            {
                                Vector3 vec = hit.collider.gameObject.transform.position;
                                Transform spawn = hit.collider.gameObject.transform;
                                //vec.y += 1;
                                spawn.position = vec;
                                Debug.Log("put2");
                                selectchicken = Instantiate(selectchicken, spawn);
                                selectchicken = bchicken;
                            }
                        }
                    }
                }
            }
            else
            {
                nochickentrue = true;
                nochickentime = 1;
            }
        }
        if (nochickentrue == true)
        {
            nochicken.SetActive(true);
            nochickentime-=Time.deltaTime;
            if (nochickentime <= 0)
            {
                nochicken.SetActive(false);
            }
        }
        
    }
    public void Bchickenbutton()
    {
        selectchicken = bchicken;
    }
    public void Swordchicken()
    {
        selectchicken = schicken;
    }
}
