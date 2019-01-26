using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{

    public bool itemSlot;
    public bool filled;
    public string itemName = "";

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            draggable.parentToReturnTo = this.transform;

            if (itemSlot)
            {
                itemName = eventData.pointerDrag.name;
                filled = true;
                GetComponentInParent<ItemSelectionManager>().checkSelection();
            }
        }
    }
}
