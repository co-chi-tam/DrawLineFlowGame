using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CLine : MonoBehaviour {

	#region Fields

	public Gradient color {
		get { 
			if (this.m_LineRenderer == null)
				return null;
			return this.m_LineRenderer.colorGradient; 
		}
		set { 
			if (this.m_LineRenderer == null)
				return;
			this.m_LineRenderer.colorGradient = value; 
		}
	}

	[SerializeField]	protected List<CCell> m_Cells;
	public List<CCell> cells {
		get { return this.m_Cells; }
		set { this.m_Cells = value; }
	}

	protected LineRenderer m_LineRenderer;

	#endregion

	#region MonoBehaviour Implementation

	protected virtual void Awake() {
		this.m_LineRenderer = this.GetComponent<LineRenderer> ();
	}

	protected virtual void LateUpdate() {
		
	}

	#endregion

	#region Main methods

	public virtual void AddCell(CCell value) {
		if (this.IsCurrentCell (value) == false) {
			this.m_Cells.Add (value);
			this.Draw ();
		} 
	}

	public virtual void RemoveCell(CCell value) {
		var index = this.m_Cells.IndexOf (value);
		if (index != -1) {
			this.m_Cells.RemoveRange (index, this.m_Cells.Count - index);
			this.m_Cells.TrimExcess ();
			this.Draw ();
		}
	}

	public virtual void Clear() {
		this.m_Cells.Clear ();
		this.m_Cells.TrimExcess ();
		this.m_LineRenderer.positionCount = 0;
	}

	public virtual void Draw() {
		this.m_LineRenderer.positionCount = this.m_Cells.Count;
		for (int i = 0; i < this.m_Cells.Count; i++) {
			var cell = this.m_Cells [i];
			this.m_LineRenderer.SetPosition (i, cell.GetPosition ());
		}
	}

	public virtual bool IsCurrentCell(CCell value) {
		return this.m_Cells.Contains (value);
	}

	public virtual bool IsCompleteLine() {
		var pointCount = 0;
		for (int i = 0; i < this.m_Cells.Count; i++) {
			var cell = this.m_Cells [i];
			if (cell is CPoint) {
				pointCount++;
				if (pointCount > 2)
					return false;
			}
		}
		return this.m_Cells.Count > 1 && this.m_Cells [0].cellName == this.m_Cells [this.m_Cells.Count - 1].cellName;
	}

	public virtual int CountCell() {
		return this.m_Cells.Count;
	}

	#endregion

}
