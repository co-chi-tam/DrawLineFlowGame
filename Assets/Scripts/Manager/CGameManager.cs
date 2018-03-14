using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleSingleton;

public class CGameManager : CMonoSingleton<CGameManager> {

	#region Fields

	[SerializeField]	protected EGameState m_GameState = EGameState.Playing;
	public EGameState gameState {
		get { return this.m_GameState; }
		set { this.m_GameState = value; }
	}

	protected CGrid m_Grid;
	protected CRootline m_RootLine;

	public enum EGameState {
		Playing = 0,
		Complete = 1,
		Fail = 2
	}

	#endregion

	#region MonoBehaviour Implementation

	protected virtual void Start ()
	{
		this.m_Grid = CGrid.GetInstance ();
		this.m_RootLine = CRootline.GetInstance ();
	}

	protected virtual void LateUpdate() {
		if (this.IsCompleteGame ()) {
			this.m_GameState = EGameState.Complete;
		} else {
			this.m_GameState = EGameState.Fail;
		}
	}

	#endregion

	#region Main methods

	public virtual bool IsCompleteGame() {
		return this.m_RootLine.IsComplete() 
			&& this.m_RootLine.CountCells () >= this.m_Grid.width * this.m_Grid.height;
	}

	#endregion

}
