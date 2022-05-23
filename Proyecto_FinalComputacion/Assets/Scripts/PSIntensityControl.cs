using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSIntensityControl : MonoBehaviour
{

    [SerializeField] ParticleSystem ps;
    [SerializeField] ParticleSystem psTrail;
    [SerializeField] ParticleSystem psExplosion;
    
    ParticleSystem.EmissionModule emission;
    ParticleSystem.MainModule main;
    ParticleSystem.EmissionModule emissionTrail;
    ParticleSystem.MainModule mainTrail;

    [SerializeField] Color anticipationColor;
    [SerializeField] Color actionColor;

    [SerializeField] Animator lightAnimator;
    [SerializeField] Animator animator;

    [SerializeField] AudioSource swordSlash;
    [SerializeField] AudioSource explosion;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.Play("Great Sword Cast");
        }
    }

    //Conseguir los componentes.
    void Awake()
    {
        emission = ps.emission;
        main = ps.main;
        emissionTrail = psTrail.emission;
        mainTrail = psTrail.main;
    }

    public void AnimIdle()
    {
        ps.Stop();
        psTrail.Stop();
    }

    //Emisión, tamaño y color inicial.
    public void AnimAnticipation() {
        ps.Play();
        psTrail.Play();
        emission.rateOverTime = 100;
        main.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        main.startColor = anticipationColor;
        emissionTrail.rateOverTime = 100;
        mainTrail.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        mainTrail.startColor = anticipationColor;
    }

    //Cambio de wmisión, tamaño y color.
    public void AnimAction() {
        lightAnimator.SetTrigger("Activate");
        emission.rateOverTime = 125;
        main.startSize = new ParticleSystem.MinMaxCurve(1f);
        main.startColor = actionColor;
        emissionTrail.rateOverTime = 25;
        mainTrail.startSize = new ParticleSystem.MinMaxCurve(0.75f);
        mainTrail.startColor = anticipationColor;
    }

    public void AnimActionTrail()
    {
        emissionTrail.rateOverTime = 25;
        mainTrail.startSize = new ParticleSystem.MinMaxCurve(1.25f);
        mainTrail.startColor = actionColor;
    }

    public void AnimDimision()
    {
        emission.rateOverTime = 5;
        main.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        main.startColor = anticipationColor;
        emissionTrail.rateOverTime = 5;
        mainTrail.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        mainTrail.startColor = anticipationColor;

    }

    public void AnimExplosion()
    {
        psExplosion.Play();
    }
    public void soundExplosion()
    {
        explosion.Play();
    }
    public void soundSword()
    {
        swordSlash.Play();
    }

}
