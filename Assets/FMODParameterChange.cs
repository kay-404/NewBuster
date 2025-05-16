using UnityEngine;
using FMODUnity;

public class FMODParameterChange : MonoBehaviour
{
    //public FMODUnity.EventReference eventReference;
    //FMOD.Studio.EventInstance eventInstance;
    string intensity = "Intensity";
    FMODUnity.StudioEventEmitter emitter;
    public int parameterValue;

    GameObject gameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject = GameObject.Find("Music");
        emitter = gameObject.GetComponent<FMODUnity.StudioEventEmitter>();

        //eventReference.Path = "event:/MUS_MainMenu";
        //eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
        //eventInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeParameterValue();

        if (gameObject.activeInHierarchy == true)
        {
            //eventInstance.setParameterByName(intensity, 1);
            emitter.SetParameter(intensity, parameterValue);
        }
    }

    private void OnDisable()
    {
        emitter.SetParameter(intensity, 0);
    }

    /*
    void ChangeParameterValue()
    {
        OnDisable();
    }

    void OnDisable()
    {
        eventInstance.setParameterByName(intensity, 1);
    }
    */
}
