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
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(MeshRenderer))]
public class WaveformGenerator : MonoBehaviour {
    
    [SerializeField]
    private int resolution = 1;

    private float[] waveForm;
    private float[] samples;

    private AudioSource audioSource;
    private LineRenderer lineRenderer;
    private MeshRenderer meshRenderer;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        lineRenderer = GetComponent<LineRenderer>();
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
        lineRenderer.SetPositions(points.ToArray());
    }

    public void OnChangeWavefornPitch(int partCount, int idPart,float modifierValue)
    {
        int pointsPerPart = lineRenderer.positionCount / partCount;

        for(int i=(pointsPerPart * idPart); i < ((pointsPerPart*idPart)+pointsPerPart-1);++i)
        {
            Vector3 positionPoint = lineRenderer.GetPosition(i);
            positionPoint.z += modifierValue;
            lineRenderer.SetPosition(i, positionPoint);
        }
    }
}
