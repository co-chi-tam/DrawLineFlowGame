using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleSingleton;

public class CGrid : CMonoSingleton<CGrid> {

	#region Fields

	[SerializeField]	protected int m_Width = 5;
	public int width {
		get { return this.m_Width; }
		set { this.m_Width = value; }
	}
	[SerializeField]	protected int m_Height = 5;
	public int height {
		get { return this.m_Height; }
		set { this.m_Height = value; }
	}
	[SerializeField]	protected GameObject m_GridRoot;
	[SerializeField]	protected GameObject m_PointPrefab;
	[SerializeField]	protected GameObject m_CellPrefab;
	[SerializeField]	protected TextAsset m_GridConfig;
	protected string gridConfig {
		get { return this.m_GridConfig.text; }
	}

	protected CCell[,] m_Grid;

	#endregion

	#region MonoBehaviour Implementation

	protected override void Awake() {
		base.Awake ();
		this.m_Grid = new CCell[this.m_Width, this.m_Height];
	}

	protected virtual void Start() {
		this.GenerateGrid ();
	}

	#endregion

	#region Main methods

	public virtual void GenerateGrid() {
		var gridStr = this.m_GridConfig.text;
		var cellStr = gridStr.Split (',');
		for (int y = 0; y < this.m_Height; y++) {
			for (int x = 0; x < this.m_Width; x++) {
				var index = (y * this.m_Width) + x;
				var cellConfig = cellStr [index];
				if (cellConfig == "0") {
					var cellObject = Instantiate (this.m_CellPrefab);
					var cellCtrl = cellObject.GetComponentInChildren<CCell> ();
					cellObject.transform.SetParent (this.m_GridRoot.transform);
					cellObject.transform.localScale = Vector3.one;
					this.m_Grid [x, y] = cellCtrl; 
				} else {
					var pointObject = Instantiate (this.m_PointPrefab);
					var pointCtrl = pointObject.GetComponentInChildren<CPoint> ();
					pointCtrl.color = hexToColor (cellConfig);
					pointCtrl.cellName = cellConfig;
					pointObject.transform.SetParent (this.m_GridRoot.transform);
					pointObject.transform.localScale = Vector3.one;
					this.m_Grid [x, y] = pointCtrl;
				}
			}
		}
	}

	public static Color hexToColor(string hex)
	{
		hex = hex.Replace ("0x", "");//in case the string is formatted 0xFFFFFF
		hex = hex.Replace ("#", "");//in case the string is formatted #FFFFFF
		byte a = 255;//assume fully visible unless specified in hex
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		//Only use alpha if the string has enough characters
		if(hex.Length == 8){
			a = byte.Parse(hex.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
		}
		return new Color32(r,g,b,a);
	}

	#endregion

}
