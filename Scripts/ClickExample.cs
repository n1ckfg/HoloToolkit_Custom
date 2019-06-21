using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExample : MonoBehaviour {

    public enum ClickMode { HEAD, HAND };
    public ClickMode clickMode = ClickMode.HAND;
    public Vector3 rot = Vector3.zero;

    [HideInInspector] public bool doRot = false;

    private BasicController ctl;
    private HoloLensHandTracking.HandsTrackingController handMgr;

    private void Awake() {
        ctl = Camera.main.GetComponent<BasicController>();
        handMgr = GameObject.FindGameObjectWithTag("HandManager").GetComponent<HoloLensHandTracking.HandsTrackingController>();
    }

    private void Update() {
        if (handMgr.handPressed) {
            if (clickMode == ClickMode.HAND && handMgr.isLookingAt == gameObject.name || clickMode == ClickMode.HEAD && ctl.isLookingAt == gameObject.name) {
                doRot = true;
            }
        } else {
            doRot = false;
        }

        if (doRot) transform.Rotate(rot);
    }

}
