using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float shootSpeed = 10f;
    public GameObject trapPrefab;
    public List<GameObject> traps;
    public Vector3 trapOffset;
    public Vector3 trapRotation;

    public Camera cam;

    private void Awake()
    {
        cam ??= Camera.main ?? GetComponent<Camera>() ?? FindFirstObjectByType<Camera>();
    }
    public void OnAttack()
    {
        Vector3 camForward = cam.transform.forward;
        camForward.y = 0f;

        camForward.Normalize();

        Vector3 spawnPosition = transform.position;
        spawnPosition.y += trapOffset.y;
        spawnPosition += (trapOffset.z * camForward);

        GameObject trap = Instantiate(trapPrefab, spawnPosition, Quaternion.Euler(transform.localEulerAngles = new Vector3(0, cam.transform.localEulerAngles.y, 0)));

        var spawmDir = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized; 

        Debug.Log(spawmDir);
        Debug.Log(spawmDir * shootSpeed);
        trap.GetComponentInChildren<Rigidbody>()?.AddForce(spawmDir * shootSpeed);
        traps.Add(trap);
    }
 }