using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSwitchScene : MonoBehaviour {

	public void LoadScene(string name) {
		SceneManager.LoadScene (name);
	}

	public void LoadSceneAfter3Second(string name) {
		StartCoroutine (this.HandleAfterTime(1f, name));
	}

	protected IEnumerator HandleAfterTime(float time, string name) {
		yield return new WaitForSeconds (time);
		this.LoadScene (name);
	}

}
