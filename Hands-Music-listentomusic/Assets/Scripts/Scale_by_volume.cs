using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// put this on the object to scale.
/// link audio source in the inspector.
/// changes scale of this object based on volume of audio source.
/// </summary>
public class ScaleThisByVolume : MonoBehaviour
{
    public AudioSource audioSource;
    public float volume;
    public float addThisMuch;
    public float multiplyByThisMuch;
    public float newScale;

    private float originalSize;

    private float clipLoudness;
	private float[] clipSampleData;

    public float updateStep = 0.1f;
	public int sampleDataLength = 1024;

	private float currentUpdateTime = 0f;


    void Start(){
        originalSize = gameObject.transform.localScale.x;
        clipSampleData = new float[sampleDataLength];
    }


    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;
		if (currentUpdateTime >= updateStep) {
			currentUpdateTime = 0f;
			audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
			clipLoudness = 0f;
			foreach (var sample in clipSampleData) {
				clipLoudness += Mathf.Abs(sample);
			}
			clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
		}


        volume = clipLoudness;
        newScale = (volume * multiplyByThisMuch + addThisMuch) * originalSize;
        gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);

    }
}
