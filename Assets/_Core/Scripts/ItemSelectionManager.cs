﻿using System.Collections;
using System.Collections.Generic;
using Assets._Core.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectionManager : MonoBehaviour
{
    public Button nextButton;

    public void checkSelection()
    {
        DropZone[] itemSlots = this.GetComponentsInChildren<DropZone>();
        int noOfSlots = 0;
        int slotsFilled = 0;

        foreach(DropZone slot in itemSlots)
        {
            if(slot.itemSlot)
            {
                noOfSlots++;
                if (slot.filled)
                {
                    slotsFilled++;
                }
            }
        }

        if (slotsFilled == noOfSlots)
        {
            nextButton.interactable = true;
        }
        else
        {
            nextButton.interactable = false;
        }
    }

    public void ConfirmSelected()
    {
        List<string> equippedItems = new List<string>();

        DropZone[] itemSlots = this.GetComponentsInChildren<DropZone>();

        foreach (DropZone slot in itemSlots)
        {
            if (slot.itemSlot)
            {
                Debug.Log("Equipping item " + slot.itemName);
                equippedItems.Add(slot.itemName);
            }
        }

        FindObjectOfType<AdventurerManager>().Equip(equippedItems);

        //FindObjectOfType<AdventurerManager>().Equip(new List<string>
        //{
        //	"Bunny Slippers",
        //	"Climbing Equipment",
        //	"Strength Potion"
        //});
    }
}
