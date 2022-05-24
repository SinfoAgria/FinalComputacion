using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXparameterization : MonoBehaviour
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
    ParticleSystem.EmissionModule impactEmission;

    [SerializeField] Animator animator;

    [SerializeField, Range(0,1)] float intensity;

    float swordChargeValue = 0;
    float trailSmokeValue = 0;
    float smokeValue = 0;

    void Start()
    {
        swordChargeMain = psMain.main;
        swordChargeEmission = psMain.emission;
        swordChargeValue = swordChargeEmission.rateOverTime.constant;

        trailSmokeMain = psTrailSmoke.main;
        trailSmokeEmission = psTrailSmoke.emission;
        trailSmokeValue = trailSmokeEmission.rateOverTime.constant;

        smokeMain = psSmoke.main;
        smokeEmission = psSmoke.emission;
        smokeValue = smokeEmission.rateOverTime.constant;

        impactMain = psImpact.main;
        impactEmission = psImpact.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            swordChargeEmission.rateOverTime = new ParticleSystem.MinMaxCurve(swordChargeValue * intensity);

            animator.Play("Great Sword Cast");
        }
    }
}
