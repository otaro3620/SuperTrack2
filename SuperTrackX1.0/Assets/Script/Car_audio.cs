using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CarControler))]
public class Car_audio : MonoBehaviour
{
    // Este script lee algunas de las propiedades actuales del automóvil y reproduce sonidos en consecuencia.
    // El sonido del motor puede ser un simple clip que está en bucle y tono, o
    // puede ser una mezcla de cuatro clips que representan el timbre del motor
    // a diferentes RPM y estado del acelerador.

    // Los clips del motor deben tener un tono constante, sin subir ni bajar.

    // cuando se utiliza el fundido cruzado del motor de cuatro canales, los cuatro clips deben ser:
    // lowAccelClip: el motor a bajas revoluciones, con el acelerador abierto (es decir, iniciando la aceleración a muy baja velocidad)
    // highAccelClip: El motor a altas revoluciones, con el acelerador abierto (es decir, acelerando, pero casi a la velocidad máxima)
    // lowDecelClip: el motor a bajas revoluciones, con el acelerador al mínimo (es decir, al ralentí o al frenado del motor a muy baja velocidad)
    // highDecelClip: el motor a altas revoluciones, con el acelerador al mínimo (es decir, frenado del motor a muy alta velocidad)

    // Para un fundido cruzado adecuado, todos los tonos de los clips deben coincidir, con un desplazamiento de octava entre graves y agudos.


    public enum EngineAudioOptions // Opciones para el audio del motor
    {
        Simple, // Audio de estilo simple
        FourChannel // audio de cuatro canales
    }

    public EngineAudioOptions engineSoundStyle = EngineAudioOptions.FourChannel;// Configure las opciones de audio predeterminadas para que sean de cuatro canales
    public AudioClip lowAccelClip;                                              // Clip de audio para baja aceleración
    public AudioClip lowDecelClip;                                              // Clip de audio para baja desaceleración
    public AudioClip highAccelClip;                                             // Audio clip for high acceleration
    public AudioClip highDecelClip;                                             // Audio clip for high deceleration
    public float pitchMultiplier = 1f;                                          // Se utiliza para modificar el tono de los clips de audio
    public float lowPitchMin = 1f;                                              // El tono más bajo posible para los sonidos graves
    public float lowPitchMax = 6f;                                              // The highest possible pitch for the low sounds
    public float highPitchMultiplier = 0.25f;                                   // Used for altering the pitch of high sounds
    public float maxRolloffDistance = 500;                                      // The maximum distance where rollof starts to take place
    public float dopplerLevel = 1;                                              // The mount of doppler effect used in the audio
    public bool useDoppler = true;                                              // Toggle for using doppler

    private AudioSource m_LowAccel; // Source for the low acceleration sounds
    private AudioSource m_LowDecel; // Source for the low deceleration sounds
    private AudioSource m_HighAccel; // Source for the high acceleration sounds
    private AudioSource m_HighDecel; // Source for the high deceleration sounds
    private bool m_StartedSound; // flag for knowing if we have started sounds
    private CarControler m_CarController; // Reference to car we are controlling


    private void StartSound()
    {
        // get the carcontroller ( this will not be null as we have require component)
        m_CarController = GetComponent<CarControler>();

        // setup the simple audio source
        m_HighAccel = SetUpEngineAudioSource(highAccelClip);

        // if we have four channel audio setup the four audio sources
        if (engineSoundStyle == EngineAudioOptions.FourChannel)
        {
            m_LowAccel = SetUpEngineAudioSource(lowAccelClip);
            m_LowDecel = SetUpEngineAudioSource(lowDecelClip);
            m_HighDecel = SetUpEngineAudioSource(highDecelClip);
        }

        // flag that we have started the sounds playing
        m_StartedSound = true;
    }


    private void StopSound()
    {
        //Destroy all audio sources on this object:
        foreach (var source in GetComponents<AudioSource>())
        {
            Destroy(source);
        }

        m_StartedSound = false;
    }


    // Update is called once per frame
    private void Update()
    {
        // obtener la distancia a la cámara principal
        float camDist = (Camera.main.transform.position - transform.position).sqrMagnitude;

        // stop sound if the object is beyond the maximum roll off distance
        if (m_StartedSound && camDist > maxRolloffDistance * maxRolloffDistance)
        {
            StopSound();
        }

        // start the sound if not playing and it is nearer than the maximum distance
        if (!m_StartedSound && camDist < maxRolloffDistance * maxRolloffDistance)
        {
            StartSound();
        }

        if (m_StartedSound)
        {
            // The pitch is interpolated between the min and max values, according to the car's revs.
            float pitch = ULerp(lowPitchMin, lowPitchMax, m_CarController.Revs);

            // clamp to minimum pitch (note, not clamped to max for high revs while burning out)
            pitch = Mathf.Min(lowPitchMax, pitch);

            if (engineSoundStyle == EngineAudioOptions.Simple)
            {
                // for 1 channel engine sound, it's oh so simple:
                m_HighAccel.pitch = pitch * pitchMultiplier * highPitchMultiplier;
                m_HighAccel.dopplerLevel = useDoppler ? dopplerLevel : 0;
                m_HighAccel.volume = 1;
            }
            else
            {
                // for 4 channel engine sound, it's a little more complex:

                // adjust the pitches based on the multipliers
                m_LowAccel.pitch = pitch * pitchMultiplier;
                m_LowDecel.pitch = pitch * pitchMultiplier;
                m_HighAccel.pitch = pitch * highPitchMultiplier * pitchMultiplier;
                m_HighDecel.pitch = pitch * highPitchMultiplier * pitchMultiplier;

                // get values for fading the sounds based on the acceleration
                float accFade = Mathf.Abs(m_CarController.AccelInput);
                float decFade = 1 - accFade;

                // get the high fade value based on the cars revs
                float highFade = Mathf.InverseLerp(0.2f, 0.8f, m_CarController.Revs);
                float lowFade = 1 - highFade;

                // adjust the values to be more realistic
                highFade = 1 - ((1 - highFade) * (1 - highFade));
                lowFade = 1 - ((1 - lowFade) * (1 - lowFade));
                accFade = 1 - ((1 - accFade) * (1 - accFade));
                decFade = 1 - ((1 - decFade) * (1 - decFade));

                // adjust the source volumes based on the fade values
                m_LowAccel.volume = lowFade * accFade;
                m_LowDecel.volume = lowFade * decFade;
                m_HighAccel.volume = highFade * accFade;
                m_HighDecel.volume = highFade * decFade;

                // adjust the doppler levels
                m_HighAccel.dopplerLevel = useDoppler ? dopplerLevel : 0;
                m_LowAccel.dopplerLevel = useDoppler ? dopplerLevel : 0;
                m_HighDecel.dopplerLevel = useDoppler ? dopplerLevel : 0;
                m_LowDecel.dopplerLevel = useDoppler ? dopplerLevel : 0;
            }
        }
    }


    // sets up and adds new audio source to the gane object
    private AudioSource SetUpEngineAudioSource(AudioClip clip)
    {
        // create the new audio source component on the game object and set up its properties
        AudioSource source = this.gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 0;
        source.loop = true;

        // start the clip from a random point
        source.time = Random.Range(0f, clip.length);
        source.Play();
        source.minDistance = 5;
        source.maxDistance = maxRolloffDistance;
        source.dopplerLevel = 0;
        return source;
    }


    // unclamped versions of Lerp and Inverse Lerp, to allow value to exceed the from-to range
    private static float ULerp(float from, float to, float value)
    {
        return (1.0f - value) * from + value * to;
    }
}

