using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Image))]
public class CPoint : CCell {

	#region Fields

	[SerializeField]	protected Color m_Color;
	public Color color {
		get { return this.m_Color; }
		set { 
			this.m_Color = value; 
			this.m_Image = this.GetComponent<Image> ();
			this.m_Image.color = this.m_Color;
		}
	}

	protected Image m_Image;

	#endregion

	#region Implementation CUIObject

	protected override void Awake ()
	{
		base.Awake ();
	}

	protected override void Start ()
	{
		base.Start ();
	}

	#endregion

	#region IPointerEnterHandler implementation

	public override void OnPointerDown (PointerEventData eventData)
	{
		base.OnPointerDown (eventData);
		this.m_RootLine.AddLine (this);
		this.m_RootLine.AddLineColor (this.m_Color);
	}

	public override void OnPointerUp (PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		this.m_RootLine.EndLine (this);
	}

	#endregion

}
