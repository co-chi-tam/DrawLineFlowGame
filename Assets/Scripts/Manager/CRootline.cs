using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleSingleton;

public class CRootline : CMonoSingleton<CRootline> {

	#region Fields

	[SerializeField]	protected CLine m_LinePrefab;
	[SerializeField]	protected CLine m_CurrentLine;
	public CLine currentLine {
		get { return this.m_CurrentLine; }
		set { this.m_CurrentLine = value; }
	}
	[SerializeField]	protected List<CLine> m_Lines;
	public List<CLine> lines {
		get { return this.m_Lines; }
		set { this.m_Lines = value; }
	}

	#endregion

	#region MonoBehaviour Implementation

	protected override void Awake ()
	{
		base.Awake ();
	}

	protected virtual void LateUpdate() {
		
	}

	#endregion

	#region Main methods

	public virtual void AddLine(CCell value) {
		CLine line = this.ContainLine (value);
		if (line == null) {
			line = Instantiate (this.m_LinePrefab);
			this.m_Lines.Add (line);
			line.name = "Line " + (this.m_Lines.Count + 1);
		} else {
			line.Clear ();
		}
		line.AddCell (value);
		line.transform.SetParent (this.transform);
		this.m_CurrentLine = line;
	}

	public virtual void AddLineColor(Color value) {
		if (this.m_CurrentLine == null)
			return;
		var gradient = new Gradient ();
		gradient.alphaKeys = new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f) };
		gradient.colorKeys = new GradientColorKey[] { new GradientColorKey (value, 0f) };
		this.m_CurrentLine.color = gradient;
	}

	public virtual void EndLine(CCell value) {
		this.m_CurrentLine = null;
	}

	public virtual CLine ContainLine(CCell value) {
		for (int i = 0; i < this.m_Lines.Count; i++) {
			var line = this.m_Lines [i];
			if (line.IsCurrentCell (value)) {
				return line;
			}
		}
		return null;
	}

	public virtual void AddCell (CCell value) {
		if (this.m_CurrentLine == null)
			return;
		CLine line = this.ContainLine (value);
		if (line != null) {
			line.RemoveCell (value);
		}
		this.m_CurrentLine.AddCell (value);
	}

	public virtual int CountCells () {
		var countLines = 0;
		for (int i = 0; i < this.m_Lines.Count; i++) {
			var line = this.m_Lines [i];
			countLines += line.CountCell();
		}
		return countLines;
	}

	public virtual bool IsComplete() {
		var completeCell = this.m_Lines.Count > 0;
		for (int i = 0; i < this.m_Lines.Count; i++) {
			var line = this.m_Lines [i];
			if (line.CountCell () > 1) {
				completeCell &= line.IsCompleteLine ();
			}
		}
		return completeCell;
	}

	#endregion

}
