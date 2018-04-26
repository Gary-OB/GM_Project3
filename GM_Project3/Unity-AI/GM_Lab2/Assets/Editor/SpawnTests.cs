using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor.SceneManagement;

public class SpawnTests {

	[Test]
	public void checkEndpointNotNull() {
		EditorSceneManager.OpenScene ("Assets/GM_Lab2.unity");
		Assert.IsNull((GameObject.FindGameObjectWithTag("endpoint")), "Object not found");
	}

	[Test]
	public void checkLavaNotNull() {
		EditorSceneManager.OpenScene ("Assets/GM_Lab2.unity");
		Assert.IsNotNull((GameObject.FindGameObjectWithTag("lava")), "Object not found");
	}

	[Test]
	public void checkTerrainNotNull() {
		EditorSceneManager.OpenScene ("Assets/GM_Lab2.unity");
		Assert.IsNotNull((GameObject.FindGameObjectWithTag("Ground")), "Object not found");
	}

	[Test]
	public void checkMainCameraNotNull() {
		EditorSceneManager.OpenScene ("Assets/GM_Lab2.unity");
		Assert.IsNotNull((GameObject.FindGameObjectWithTag("MainCamera")), "Object not found");
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator AssetTestsWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
