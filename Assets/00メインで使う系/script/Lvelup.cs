using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvelup : MonoBehaviour
{
    public PlayerManager player;
    SwordChicken swordChicken;
    Chicken chicken;
    GameObject schicken;
    GameObject bchicken;
    public GameObject chick;
    public int s2;
    public int s3;
    public int b2;
    public int b3;
    public bool sword2 = false;
    public bool sword3 = false;
    public bool bow2 = false;
    public bool bow3 = false;
    int spower;
    int bpower;

     void Start()
    {
        //player = GetComponent<PlayerManager>();//�Q�[���I�u�W�F�N�g�������ĂȂ����炱�̏������ł̓_�������@���̏������Ȃ炱���v��Ȃ���������Ȃ�
    }
    public void LvelS2()
    {
        if (player.sword2 > 0)
        {
            sword2 = true;
            bow2 = false;
            bow3 = false;
            sword3 = false;
            spower = 1;
        }
        else
        {

        }
    }
    public void LvelS3()
    {
        if (player.sword3 > 0)
        {
            sword3 = true;
            sword2 = false;
            bow2 = false;
            bow3 = false;
            spower = 2;
        }
        else
        {

        }
            
    }
    public void LvelB2()
    {
        if (player.bow2 > 0)
        {
            bow2 = true;
            sword2 = false;
            bow3 = false;
            sword3 = false;
            bpower = 1;
        }
        else
        {

        }
            
    }
    public void LvelB3()
    {
        if (player.bow3 > 0)
        {
            bow3 = true;
            sword2 = false;
            bow2 = false;
            sword3 = false;
            bpower = 2;
        }
        else
        {

        }
            
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                chick = hit.collider.gameObject;
                swordChicken = hit.collider.GetComponent<SwordChicken>();
                Debug.Log(swordChicken);
                chicken = hit.collider.GetComponent<Chicken>();
                if (chick.CompareTag("chicken"))
                {
                    Debug.Log("�ɂ�Ƃ�2");
                    if (chick.GetComponent<BowChicken>())
                    {
                        if (bow2 == true)
                        {
                            if (player.bow2 > 0)
                            {
                                if (chicken.level < 1)
                                {
                                    chicken.level = 1;
                                    chicken.Weapon2();
                                }
                            }
                            else
                            {
                                //�|������Ȃ��I�Ȃ��̕\��
                            }
                        }
                        else if (bow3 == true)
                        {
                            if (chicken.level < 2)
                            {
                                chicken.level = 2;
                                chicken.Weapon3();
                            }
                        }
                    }
                    else if (chick.GetComponent<SwordChicken>())
                    {
                        Debug.Log("�ɂ�Ƃ�3");
                        if (sword2 == true)
                        {
                            Debug.Log("��21");
                            if (player.sword2 > 0)
                            {
                                Debug.Log("��22");
                                if (chicken.level < 1)
                                {
                                    Debug.Log("��23");
                                    chicken.level = 1;
                                    chicken.Weapon2();
                                }
                            }
                        }
                        else if (sword3 == true)
                        {
                            Debug.Log("��31");
                            if (player.sword3 > 0)
                            {
                                Debug.Log("��32");
                                if (chicken.level < 2)
                                {
                                    Debug.Log("��33");
                                    chicken.level = 2;
                                    chicken.Weapon3();
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("�̌�");
                    }
                }
                else
                {
                    Debug.Log("�ɂ�Ƃ�Ⴄ");
                }
            }
        }
        
    }
}
