using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class CCell : CUIObject, 
IBeginDragHandler, IDragHandler, IEndDragHandler, 
IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{

	#region Fields

	[SerializeField]	protected string m_CellName = "Empty";
	public string cellName {
		get { return this.m_CellName; }
		set { this.m_CellName = value; }
	}

	protected CRootline m_RootLine;
	protected bool m_IsHold = false;

	#endregion

	#region Implementation CUIObject

	protected override void Start ()
	{
		base.Start ();
		this.m_RootLine = CRootline.GetInstance ();
	}

	protected override void LateUpdate ()
	{
		base.LateUpdate ();
//		if (this.m_IsHold) {
//			this.m_RootLine.AddCell (this);
//		}
	}

	#endregion

	#region IPointer implementation

	public override void OnPointerEnter (PointerEventData eventData)
	{
		base.OnPointerEnter (eventData);
		this.m_IsHold = true;
		this.m_RootLine.AddCell (this);
	}

	public override void OnPointerExit (PointerEventData eventData)
	{
		base.OnPointerExit (eventData);
		this.m_IsHold = false;
	}

	public override void OnPointerDown (PointerEventData eventData)
	{
		base.OnPointerDown (eventData);
	}

	public override void OnPointerUp (PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
	}

	#endregion

}
