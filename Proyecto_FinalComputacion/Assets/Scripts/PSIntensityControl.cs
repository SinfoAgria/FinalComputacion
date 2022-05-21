using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSIntensityControl : MonoBehaviour
{

    ParticleSystem ps;
    ParticleSystem.EmissionModule emission;
    ParticleSystem.MainModule main;

    [SerializeField] Color anticipationColor;
    [SerializeField] Color actionColor;

    [SerializeField] Animator lightAnimator;

    //Conseguir los componentes.
    void Awake()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        emission = ps.emission;
        main = ps.main;
    }

    public void AnimIdle()
    {
        ps.Stop();
    }

    //Emisión, tamaño y color inicial.
    public void AnimAnticipation() {
        ps.Play();
        emission.rateOverTime = 100;
        main.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        main.startColor = anticipationColor;
    }

    //Cambio de wmisión, tamaño y color.
    public void AnimAction() {
        lightAnimator.SetTrigger("Activate");
        emission.rateOverTime = 10;
        main.startSize = new ParticleSystem.MinMaxCurve(1f);
        main.startColor = actionColor;
    }

}
