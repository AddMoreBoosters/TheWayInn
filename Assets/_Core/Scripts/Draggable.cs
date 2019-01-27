using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Assets._Core.Scripts;


public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Transform parentToReturnTo = null;
    private Vector3 startPosition;
    public AudioClip soundfx;

    private void Start()
    {
        startPosition = this.transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        LayoutElement layout = GetComponent<LayoutElement>();
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, layout.preferredWidth);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, layout.preferredHeight);

        if (soundfx != null)
        {
            
        }

        parentToReturnTo = this.transform.parent;
        DropZone parentDropZone = GetComponentInParent<DropZone>();
        if (parentDropZone != null)
        {
            if(parentDropZone.itemSlot)
            {
                parentDropZone.filled = false;
                parentDropZone.itemName = "";
                GetComponentInParent<ItemSelectionManager>().checkSelection();
            }
        }
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        DropZone parentDropZone = GetComponentInParent<DropZone>();
        if (parentDropZone != null)
        {
            if (parentDropZone.itemSlot)
            {
                parentDropZone.itemName = this.name;
                parentDropZone.filled = true;
                GetComponentInParent<ItemSelectionManager>().checkSelection();
            }
            else
            {
                Debug.Log("Move to start position");
                //this.transform.position.Set(startPosition.x, startPosition.y, startPosition.z);
                GetComponent<RectTransform>().SetPositionAndRotation(startPosition, new Quaternion(0, 0, 0, 0));
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
	    transform.DOScale(Vector3.one * 1.1f, .2f);
    }

    public void OnPointerExit(PointerEventData eventData)
	{
		transform.DOScale(Vector3.one, .2f);
	}
}
