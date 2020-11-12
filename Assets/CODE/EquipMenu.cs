using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipMenu : MonoBehaviour
{
    EventSystem m_EventSystem;

    GameObject lastselect;

    public Image slotD;
    public Image slotC;
    //public Image slotSpace;


    public Player player;


    public RectTransform highlight;



    public int[] slots = { 0, 0, 0 };

    List<int> slotduplicates = new List<int>();

    Image img;
    void OnEnable()
    {
        //Fetch the current EventSystem. Make sure your Scene has one.
        m_EventSystem = EventSystem.current;
        //m_EventSystem.SetSelectedGameObject(gameObject);
    }


    // Use this for initialization
    void Start()
    {

        img = GetComponent<Image>();
        //lastselect= m_EventSystem.currentSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {




        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }




        highlight.anchoredPosition = lastselect.GetComponent<RectTransform>().anchoredPosition;


        if (Input.GetKeyDown(KeyCode.D))
        {
            slotduplicates.Clear();
            InventoryItem i = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>();



            if (i.unlocked)
            {
                bool exist = false;

                if (i.isEmpty != true)
                {



                    for (int ii = 0; ii < slots.Length; ii++)
                    {

                        if (slots[ii] == i.id)
                        {
                            exist = true;
                            slotduplicates.Add(ii);
                        }



                    }


                    if (exist)
                    {
                        foreach (int iii in slotduplicates)
                        {

                            switch (iii)
                            {
                                case 0:
 
                                    slotD.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
                                    player.DWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
                                    slots[0] = i.id;



                                    break;


                                case 1:
                                    slotC.sprite = img.sprite;
                                    player.CWPN.Dispose();
                                    player.CWPN = null;
                                    slots[1] = 0;


                                    slotD.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
                                    player.DWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
                                    slots[0] = i.id;
                                    break;


                                case 2:
                                    //slotSpace.sprite = img.sprite;
                                    //player.SPACEWPN.Dispose();
                                    //player.SPACEWPN = null;
                                    slots[2] = 0;

                                    slotD.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
                                    player.DWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
                                    slots[0] = i.id;
                                    break;


                            }


                        }



                    }
                    else
                    {
                        try { player.DWPN.Dispose(); } catch (Exception e) { }
                        slotD.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
                        player.DWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
                        slots[0] = i.id;
                    }




                }
                else
                {
                    slotD.sprite = img.sprite;
                    player.DWPN.Dispose();
                    player.DWPN = null;
                    slots[0] = 0;
                }
            }
            else
            {
                slotD.sprite = img.sprite;
                if (player.DWPN != null)
                    player.DWPN.Dispose();
                player.DWPN = null;
                slots[0] = 0;
            }



            //Debug.Log(m_EventSystem.currentSelectedGameObject.name);



        }



        if (Input.GetKeyDown(KeyCode.C))
        {
            slotduplicates.Clear();
            InventoryItem i = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>();


            if(i.unlocked)
            {
                bool exist = false;

                if (i.isEmpty != true)
                {



                    for (int ii = 0; ii < slots.Length; ii++)
                    {

                        if (slots[ii] == i.id)
                        {
                            exist = true;
                            slotduplicates.Add(ii);
                        }



                    }


                    if (exist)
                    {
                        foreach (int iii in slotduplicates)
                        {

                            switch (iii)
                            {
                                case 0:

                                    slotD.sprite = img.sprite;
                                    player.DWPN.Dispose();
                                    player.DWPN = null;
                                    slots[0] = 0;


                                    slotC.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
                                    player.CWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
                                    slots[1] = i.id;


                                    break;


                                case 1:


                                    player.CWPN.Dispose();
                                    slotC.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
                                    player.CWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
                                    slots[1] = i.id;




                                    break;


                                case 2:
                                    //slotSpace.sprite = img.sprite;
                                    //player.SPACEWPN.Dispose();
                                    //player.SPACEWPN = null;
                                    slots[2] = 0;

                                    slotC.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
                                    player.CWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
                                    slots[1] = i.id;
                                    break;


                            }


                        }



                    }
                    else
                    {
                        try
                        {
                            player.CWPN.Dispose();
                        }
                        catch (Exception e) { }

                        slotC.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
                        player.CWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
                        slots[1] = i.id;
                    }




                }
                else
                {
                    slotC.sprite = img.sprite;
                    try { player.CWPN.Dispose(); } catch (Exception e) { };
                    player.CWPN = null;
                    slots[1] = 0;
                }

                //Debug.Log(m_EventSystem.currentSelectedGameObject.name);



            }
            else
            {
                slotC.sprite = img.sprite;
                try { player.CWPN.Dispose(); } catch (Exception e) { };
                player.CWPN = null;
                slots[1] = 0;

            }



        }



        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    slotduplicates.Clear();
        //    InventoryItem i = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>();


        //    if(i.unlocked)
        //    {
        //        bool exist = false;

        //        if (i.isEmpty != true)
        //        {



        //            for (int ii = 0; ii < slots.Length; ii++)
        //            {

        //                if (slots[ii] == i.id)
        //                {
        //                    exist = true;
        //                    slotduplicates.Add(ii);
        //                }



        //            }


        //            if (exist)
        //            {
        //                foreach (int iii in slotduplicates)
        //                {

        //                    switch (iii)
        //                    {
        //                        case 0:

        //                            slotX.sprite = img.sprite;
        //                            player.XWPN.Dispose();
        //                            player.XWPN = null;
        //                            slots[0] = 0;


        //                            slotSpace.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
        //                            player.SPACEWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
        //                            slots[2] = i.id;


        //                            break;


        //                        case 1:



        //                            slotC.sprite = img.sprite;
        //                            player.CWPN.Dispose();
        //                            player.CWPN = null;
        //                            slots[1] = 0;


        //                            slotSpace.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
        //                            player.SPACEWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
        //                            slots[2] = i.id;




        //                            break;


        //                        case 2:
        //                            player.SPACEWPN.Dispose();
        //                            slotSpace.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
        //                            player.SPACEWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
        //                            slots[2] = i.id;

        //                            break;
        //                    }


        //                }



        //            }
        //            else
        //            {

        //                try { player.SPACEWPN.Dispose(); } catch (Exception e) { }
        //                slotSpace.sprite = m_EventSystem.currentSelectedGameObject.GetComponent<Image>().sprite;
        //                player.SPACEWPN = m_EventSystem.currentSelectedGameObject.GetComponent<InventoryItem>().weapon;
        //                slots[2] = i.id;
        //            }



        //        }
        //        else
        //        {
        //            slotSpace.sprite = img.sprite;
        //            try { player.SPACEWPN.Dispose(); } catch (Exception e) { }

        //            player.SPACEWPN = null;
        //            slots[2] = 0;
        //        }

        //        //Debug.Log(m_EventSystem.currentSelectedGameObject.name);



        //    }
        //    else
        //    {
        //        slotSpace.sprite = img.sprite;
        //        try { player.SPACEWPN.Dispose(); } catch (Exception e) { }

        //        player.SPACEWPN = null;
        //        slots[2] = 0;

        //    }



        //}





    }
}
