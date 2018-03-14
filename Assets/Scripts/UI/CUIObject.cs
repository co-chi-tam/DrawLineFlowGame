using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class CUIObject : MonoBehaviour, 
IBeginDragHandler, IDragHandler, IEndDragHandler, 
IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler 
{

	#region Implementation MonoBehaviour

	protected virtual void Awake() {

	}

	protected virtual void Start() {

	}

	protected virtual void FixedUpdate() {

	}

	protected virtual void Update() {

	}

	protected virtual void LateUpdate() {

	}

	public virtual Vector3 GetPosition() {
		var position = this.transform.position;
		position.z = 1f;
		return position;
	}

	#endregion

	#region Interface implementation

	public virtual void OnBeginDrag (PointerEventData eventData)
	{

	}

	public virtual void OnDrag (PointerEventData eventData)
	{

	}

	public virtual void OnEndDrag (PointerEventData eventData)
	{

	}

	#endregion

	#region IPointerEnterHandler implementation

	public virtual void OnPointerEnter (PointerEventData eventData)
	{

	}

	public virtual void OnPointerExit (PointerEventData eventData)
	{

	}

	public virtual void OnPointerDown (PointerEventData eventData)
	{

	}

	public virtual void OnPointerUp (PointerEventData eventData)
	{

	}

	#endregion

	#region Implementation Object

	public override int GetHashCode ()
	{
		return base.GetHashCode ();
		int hash = 13;
		hash = (hash * 7) + this.gameObject.GetInstanceID();
		return hash;
	}

	#endregion

}
