using UnityEngine;

public class DestroyAudioSource : MonoBehaviour {

	void Start () 
	{
		float t = GetComponent<AudioSource> ().clip.length;//Speichert die Länge des AudioClips in einen float
		Destroy (gameObject, t); //Zerstört die Audio Source nach einer bestimmten Zeit
	}
}
