﻿using System.Collections;
using System.Collections.Generic;
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
}
