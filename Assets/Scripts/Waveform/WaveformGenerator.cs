using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class EventDelegate
{
    public delegate void ChangeWaveformPitchHandler(int partCount, int idPart,float pitchModifier);
    public static event ChangeWaveformPitchHandler ChangeWaveformPitch;
    public static void FireChangeWaveFormPitch(int partCount, int idPart, float pitchModifier)
    {
        if(ChangeWaveformPitch != null)
        {
            ChangeWaveformPitch(partCount, idPart, pitchModifier);
        }
    }
}

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
public class WaveformGenerator : MonoBehaviour {
    
    [SerializeField]
    private int resolution = 1;

    [SerializeField]
    private LineRenderer lineRenderer = null;
    [SerializeField]
    private LineRenderer ghostLinerenderer = null;

    private float[] waveForm;
    private float[] samples;

    private AudioSource audioSource = null;
    private MeshRenderer meshRenderer = null;
    // Use this for initialization
    void Awake () {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();

        DrawWaveform();

        EventDelegate.ChangeWaveformPitch += OnChangeWavefornPitch;
    }

    private void OnDestroy()
    {
        EventDelegate.ChangeWaveformPitch -= OnChangeWavefornPitch;
    }

    public void DrawWaveform()
    {
        resolution = audioSource.clip.frequency / resolution;

        samples = new float[audioSource.clip.samples * audioSource.clip.channels];
        audioSource.clip.GetData(samples, 0);
        
        waveForm = new float[(samples.Length / resolution)];

        for(int i=0;i<waveForm.Length;++i)
        {
            waveForm[i] = 0;

            for(int j = 0; j < resolution; ++j)
            {
                waveForm[i] += Mathf.Abs(samples[(i * resolution) + j]);
            }
            waveForm[i] /= resolution;
        }

        List<Vector3> points = new List<Vector3>();

        float sizeX = meshRenderer.bounds.size.x / transform.localScale.x;
        float extentX = meshRenderer.bounds.extents.x / transform.localScale.x;

        for (int i = 0; i < waveForm.Length; ++i)
        {
            points.Add(new Vector3((i* sizeX / (waveForm.Length -1)) - extentX, 0.1f, waveForm[i]*10));
        }

        lineRenderer.positionCount = points.Count;
        ghostLinerenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());

        for (int i = 0; i < points.Count; ++i)
        {
            Vector3 point = points[i];
            point.y = 0.05f;
            points[i] = point;
        }

        ghostLinerenderer.SetPositions(points.ToArray());
    }

    public void OnChangeWavefornPitch(int partCount, int idPart,float modifierValue)
    {
        int pointsPerPart = ghostLinerenderer.positionCount / partCount;

        for(int i=(pointsPerPart * idPart); i < ((pointsPerPart*idPart)+pointsPerPart);++i)
        {
            Vector3 positionPoint = ghostLinerenderer.GetPosition(i);
            positionPoint.z += modifierValue;
            ghostLinerenderer.SetPosition(i, positionPoint);
        }
    }
}
