using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

    private Rigidbody Rigidbody;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        Rigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.recording)
        {
            Record();
        } else
        {
            PlayBack();
        }
    }

    void PlayBack()
    {
        Rigidbody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        print("Reading frame " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    private void Record ()
    {
        Rigidbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        print("Writing frame " + frame);

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}


/// <summary>
/// A structure for storing time, position and rotation.
/// </summary>
public struct MyKeyFrame {

    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation)
    {
        frameTime = aTime;
        position = aPosition;
        rotation = aRotation;
    }










}
