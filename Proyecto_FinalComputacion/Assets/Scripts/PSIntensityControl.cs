using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSIntensityControl : MonoBehaviour
{
    [SerializeField] ParticleSystem psMain;
    ParticleSystem.MainModule swordChargeMain;
    ParticleSystem.EmissionModule swordChargeEmission;

    [SerializeField] ParticleSystem psTrailSmoke;
    ParticleSystem.MainModule trailSmokeMain;
    ParticleSystem.EmissionModule trailSmokeEmission;

    [SerializeField] ParticleSystem psSmoke;
    ParticleSystem.MainModule smokeMain;
    ParticleSystem.EmissionModule smokeEmission;

    [SerializeField] ParticleSystem psImpact;
    ParticleSystem.MainModule impactMain;

    [SerializeField] ParticleSystem psFissure;
    ParticleSystem.MainModule fissureMain;

    [SerializeField] Animator animator;
  
    ParticleSystem.ColorOverLifetimeModule swordChargeColor;
    ParticleSystem.ColorOverLifetimeModule trailSmokeColor;
    ParticleSystem.ColorOverLifetimeModule smokeColor;
    [SerializeField] Color newColor;

    [SerializeField, Range(0, 1)] float intensity;
    [SerializeField, Range(0.25f, 2f)] float speedMultiplier = 1f;

    [SerializeField] ParticleSystem psExplosion;
    ParticleSystem.MainModule explosiveMain;

    [SerializeField] Color anticipationColor;
    [SerializeField] Color actionColor;

    [SerializeField] Animator lightAnimator;

    [SerializeField] AudioSource swordSlash;
    [SerializeField] AudioSource explosion;

    float animatorInitialSpeed = 1f;

    const float volumeImpact = 0.5f;

    public void Intensity(float value) => intensity = value;
    public void SpeedMultiplier(float value) => speedMultiplier = Mathf.Clamp(value, 0.25f, 2f);

    void Start()
    {
        swordChargeMain = psMain.main;
        swordChargeEmission = psMain.emission;
        swordChargeColor = psMain.colorOverLifetime;

        trailSmokeMain = psTrailSmoke.main;
        trailSmokeEmission = psTrailSmoke.emission;
        trailSmokeColor = psTrailSmoke.colorOverLifetime;

        smokeMain = psSmoke.main;
        smokeEmission = psSmoke.emission;
        smokeColor = psSmoke.colorOverLifetime;

        impactMain = psImpact.main;
        fissureMain = psFissure.main;
        explosiveMain = psExplosion.main;

        animatorInitialSpeed = animator.speed;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("StartAnim");       
        }
    }

    public void AnimIdle()
    {
        psMain.Stop();
        psTrailSmoke.Stop();
        psSmoke.Stop();
        psImpact.Stop();
    }

    //Emisión, tamaño y color inicial.
    public void AnimAnticipation() {
        psMain.Play();
        psTrailSmoke.Play();
        psSmoke.Play();
        psImpact.Play();
        swordChargeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(100 * intensity);
        swordChargeMain.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        swordChargeMain.startColor = anticipationColor;
        swordChargeColor.color = new ParticleSystem.MinMaxGradient(newColor);
        swordChargeMain.simulationSpeed = speedMultiplier;

        trailSmokeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(100 * intensity);
        trailSmokeEmission.rateOverDistance = new ParticleSystem.MinMaxCurve(100 * intensity);
        trailSmokeMain.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        trailSmokeMain.startColor = anticipationColor;
        trailSmokeColor.color = new ParticleSystem.MinMaxGradient(newColor);
        trailSmokeMain.simulationSpeed = speedMultiplier;

        smokeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(100 * intensity);
        smokeMain.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        smokeMain.startColor = anticipationColor;
        smokeColor.color = new ParticleSystem.MinMaxGradient(newColor);
        smokeMain.simulationSpeed = speedMultiplier;

        impactMain.startSize = new ParticleSystem.MinMaxCurve(0.25f * intensity);
        impactMain.simulationSpeed = speedMultiplier;

        fissureMain.simulationSpeed = speedMultiplier;

        animator.speed = animatorInitialSpeed * speedMultiplier;

    }

    //Cambio de emisión, tamaño y color.
    public void AnimAction() {
        lightAnimator.SetTrigger("Activate");
        swordChargeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(125 * intensity);
        swordChargeMain.startSize = new ParticleSystem.MinMaxCurve(1f);
        swordChargeMain.startColor = actionColor;
        swordChargeMain.simulationSpeed = speedMultiplier;

        trailSmokeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(125 * intensity);
        trailSmokeEmission.rateOverDistance = new ParticleSystem.MinMaxCurve(125 * intensity);
        trailSmokeMain.startSize = new ParticleSystem.MinMaxCurve(0.75f);
        trailSmokeMain.startColor = actionColor;
        trailSmokeMain.simulationSpeed = speedMultiplier;

        smokeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(125 * intensity);
        smokeMain.startSize = new ParticleSystem.MinMaxCurve(1f);
        smokeMain.startColor = actionColor;
        smokeMain.simulationSpeed = speedMultiplier;

        impactMain.startSize = new ParticleSystem.MinMaxCurve(3f * intensity);
        impactMain.simulationSpeed = speedMultiplier;

        fissureMain.simulationSpeed = speedMultiplier;

        animator.speed = animatorInitialSpeed * speedMultiplier;
    }

    public void AnimActionTrail()
    {
        trailSmokeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(25 * intensity);
        trailSmokeEmission.rateOverDistance = new ParticleSystem.MinMaxCurve(25 * intensity);
        trailSmokeMain.startSize = new ParticleSystem.MinMaxCurve(1.25f);
        trailSmokeMain.startColor = actionColor;
        trailSmokeMain.simulationSpeed = speedMultiplier;

        animator.speed = animatorInitialSpeed * speedMultiplier;
    }

    public void AnimDimision()
    {
        swordChargeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(5 * intensity);
        swordChargeMain.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        swordChargeMain.startColor = anticipationColor;
        swordChargeMain.simulationSpeed = speedMultiplier;

        trailSmokeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(5 * intensity);
        trailSmokeEmission.rateOverDistance = new ParticleSystem.MinMaxCurve(5 * intensity);
        trailSmokeMain.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        trailSmokeMain.startColor = anticipationColor;
        trailSmokeMain.simulationSpeed = speedMultiplier;

        smokeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(5 * intensity);
        smokeMain.startSize = new ParticleSystem.MinMaxCurve(0.25f);
        smokeMain.startColor = anticipationColor;
        smokeMain.simulationSpeed = speedMultiplier;

        impactMain.startSize = new ParticleSystem.MinMaxCurve(0.25f * intensity);
        impactMain.simulationSpeed = speedMultiplier;

        fissureMain.simulationSpeed = speedMultiplier;

        animator.speed = animatorInitialSpeed * speedMultiplier;
    }

    public void AnimExplosion()
    {
        psExplosion.Play();
        explosiveMain.simulationSpeed = speedMultiplier;
        lightAnimator.SetTrigger("Activate");
    }
    public void soundExplosion()
    {
        explosion.volume = intensity * volumeImpact + (1 - volumeImpact);
        explosion.pitch = speedMultiplier;
        explosion.Play();
    }
    public void soundSword()
    {
        swordSlash.volume = intensity * volumeImpact + (1 - volumeImpact);
        swordSlash.pitch = speedMultiplier;
        swordSlash.Play();
    }

}
