using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public string objName;

    [System.Serializable]
    public class MoveObject
    {
        public Transform objectToMove;
        public Vector3[] localMoveBasedOnOriginal;
        public Vector3[] worldMove;
        public Transform[] poses;

        public float vel = 5;
        public bool lerp;

        [HideInInspector]
        public Vector3 originalLocal;
        [HideInInspector]
        public int witchPos;
        [HideInInspector]
        public int count;
    }
    public MoveObject[] moveObject;

    [System.Serializable]
    public class RotateObject
    {
        public Transform objectToRotate;
        public Vector3[] eulerAnglesToGo;

        public float vel = 5;
        public bool lerp;

        [HideInInspector]
        public int witchRot;
    }
    public RotateObject[] rotateObject;

    [System.Serializable]
    public class ScaleObject
    {
        public Transform objectToScale;
        public Vector3[] scalesToGo;

        public float vel = 5;
        public bool lerp;

        [HideInInspector]
        public int witchScl;
    }
    public ScaleObject[] scaleObject;

    [System.Serializable]
    public class BlendShapeObjs
    {
        public SkinnedMeshRenderer objectToBlendShape;
        public int blendShape;
        public int[] values;

        public float vel = 3;
        public bool lerp;

        [HideInInspector]
        public int witchBlend;
    }
    public BlendShapeObjs[] blendShapeObjs;

    public GameObject[] activeChange;

    public ParticleSystem[] particleEmitChange;

    [System.Serializable]
    public class AnimateObjs
    {
        public Animator objectToAnimate;
        public string varName;
        public enum VarType
        {
            Bool, Float, Integer
        }
        public VarType varType;
        public float floatValue;
        public int integerValue;

        [HideInInspector]
        public float floatBefore;
        [HideInInspector]
        public int intBefore;
    }
    public AnimateObjs[] animateObjects;

    [System.Serializable]
    public class MaterialChange
    {
        public Renderer whos;
        public int matIndex;
        public Material changeTo;
        public string changePropetyName;
        public bool changeFloat;
        public float changePropetyValueFloat;
        public bool changeInt;
        public int changePropetyValueInteger;
        public bool changeColor;
        public Color changePropetyColor;

        [HideInInspector]
        public bool toggle;
        [HideInInspector]
        public MaterialChange backMatChange;
    }
    public MaterialChange[] materialChangePropetys;

    public Interactable[] autoInteract;

    public float recuo;

    public bool auto;

    public float tempoRecuo;

    void Start() {
        if (moveObject.Length > 0)
        {
            for (int i = 0; i < moveObject.Length; i++)
            {
                if (moveObject[i].localMoveBasedOnOriginal.Length > 0)
                {
                    moveObject[i].originalLocal = moveObject[i].objectToMove.localPosition;
                    moveObject[i].count = moveObject[i].localMoveBasedOnOriginal.Length;
                }
                if (moveObject[i].worldMove.Length > 0)
                    moveObject[i].count = moveObject[i].worldMove.Length;
                if (moveObject[i].poses.Length > 0)
                    moveObject[i].count = moveObject[i].poses.Length;
            }
        }
        if (auto)
            Interact();
    }

    void Update() {
        if (moveObject.Length > 0)
        {
            for (int i = 0; i < moveObject.Length; i++)
            {
                if (moveObject[i].localMoveBasedOnOriginal.Length > 0)
                {
                    float dist = Vector3.Distance(moveObject[i].objectToMove.localPosition, moveObject[i].originalLocal + moveObject[i].localMoveBasedOnOriginal[moveObject[i].witchPos]);
                    if (dist > 0.01f)
                        moveObject[i].objectToMove.localPosition = Vector3.Lerp(moveObject[i].objectToMove.localPosition, moveObject[i].originalLocal + moveObject[i].localMoveBasedOnOriginal[moveObject[i].witchPos], Time.deltaTime * moveObject[i].vel / (moveObject[i].lerp ? 1 : dist / 2));
                }
                if (moveObject[i].worldMove.Length > 0)
                {
                    float dist = Vector3.Distance(moveObject[i].objectToMove.position, moveObject[i].worldMove[moveObject[i].witchPos]);
                    if (dist > 0.01f)
                        moveObject[i].objectToMove.position = Vector3.Lerp(moveObject[i].objectToMove.position, moveObject[i].worldMove[moveObject[i].witchPos], Time.deltaTime * moveObject[i].vel / (moveObject[i].lerp ? 1 : dist / 2));
                }
                if (moveObject[i].poses.Length > 0)
                {
                    float dist = Vector3.Distance(moveObject[i].objectToMove.position, moveObject[i].poses[moveObject[i].witchPos].position);
                    if (dist > 0.01f)
                        moveObject[i].objectToMove.position = Vector3.Lerp(moveObject[i].objectToMove.position, moveObject[i].poses[moveObject[i].witchPos].position, Time.deltaTime * moveObject[i].vel / (moveObject[i].lerp ? 1 : dist / 2));
                }
            }
        }
        if (rotateObject.Length > 0)
        {
            for (int i = 0; i < rotateObject.Length; i++)
            {
                if (rotateObject[i].eulerAnglesToGo.Length > 0)
                {
                    float dist = Quaternion.Angle(rotateObject[i].objectToRotate.localRotation, Quaternion.Euler(rotateObject[i].eulerAnglesToGo[rotateObject[i].witchRot]));
                    if (dist > 1f)
                        rotateObject[i].objectToRotate.localRotation = Quaternion.Lerp(rotateObject[i].objectToRotate.localRotation, Quaternion.Euler(rotateObject[i].eulerAnglesToGo[rotateObject[i].witchRot]), Time.deltaTime * rotateObject[i].vel / (rotateObject[i].lerp ? 1 : dist/50));
                }
            }
        }
        if(scaleObject.Length > 0)
        {
            for (int i = 0; i < scaleObject.Length; i++)
            {
                if (scaleObject[i].scalesToGo.Length > 0)
                {
                    float dist = Vector3.Distance(scaleObject[i].objectToScale.localScale, scaleObject[i].scalesToGo[scaleObject[i].witchScl]);
                    if (dist > 0.1f)
                        scaleObject[i].objectToScale.localScale = Vector3.Lerp(scaleObject[i].objectToScale.localScale, scaleObject[i].scalesToGo[scaleObject[i].witchScl], Time.deltaTime * scaleObject[i].vel / (scaleObject[i].lerp ? 1 : dist / 10));
                }
            }
        }
        if(blendShapeObjs.Length > 0)
        {
            for(int i = 0; i < blendShapeObjs.Length; i++)
            {
                if(blendShapeObjs[i].values.Length > 0)
                {
                    float blendOrig = blendShapeObjs[i].objectToBlendShape.GetBlendShapeWeight(blendShapeObjs[i].blendShape);
                    float dist = Mathf.Abs(blendShapeObjs[i].values[blendShapeObjs[i].witchBlend]-blendOrig);
                    if (dist > 0.01f)
                        blendShapeObjs[i].objectToBlendShape.SetBlendShapeWeight(blendShapeObjs[i].blendShape, Mathf.Lerp(blendOrig, blendShapeObjs[i].values[blendShapeObjs[i].witchBlend], Time.deltaTime * blendShapeObjs[i].vel / (blendShapeObjs[i].lerp ? 1 : dist)));
                }
            }
        }

        if (tempoRecuo > 0)
            tempoRecuo -= Time.deltaTime;
    }

    public void Interact()
    {
        if (tempoRecuo > 0)
            return;
        if (moveObject.Length > 0)
            for (int i = 0; i < moveObject.Length; i++)
            {
                if (moveObject[i].count == 0)
                    Start();
                moveObject[i].witchPos = (moveObject[i].witchPos + 1) % moveObject[i].count;
            }
        if (rotateObject.Length > 0)
            for (int i = 0; i < rotateObject.Length; i++)
            {
                rotateObject[i].witchRot = (rotateObject[i].witchRot + 1) % rotateObject[i].eulerAnglesToGo.Length;
            }
        if (scaleObject.Length > 0)
            for (int i = 0; i < scaleObject.Length; i++)
            {
                scaleObject[i].witchScl = (scaleObject[i].witchScl + 1) % scaleObject[i].scalesToGo.Length;
            }
        if (blendShapeObjs.Length > 0)
            for (int i = 0; i < blendShapeObjs.Length; i++)
            {
                blendShapeObjs[i].witchBlend = (blendShapeObjs[i].witchBlend + 1) % blendShapeObjs[i].values.Length;
            }

        for (int i = 0; i < activeChange.Length; i++)
            activeChange[i].SetActive(!activeChange[i].activeInHierarchy);
        for (int i = 0; i < particleEmitChange.Length; i++)
        {
            ParticleSystem[] ps = particleEmitChange[i].GetComponentsInChildren<ParticleSystem>();
            for (int j = 0; j < ps.Length; j++)
            {
                if (ps[j].isPlaying)
                    ps[j].Stop();
                else
                    ps[j].Play();
            }
        }
        if (animateObjects.Length > 0)
            for (int i = 0; i < animateObjects.Length; i++)
            {
                switch (animateObjects[i].varType)
                {
                    case AnimateObjs.VarType.Bool:
                        animateObjects[i].objectToAnimate.SetBool(animateObjects[i].varName, !animateObjects[i].objectToAnimate.GetBool(animateObjects[i].varName));
                        break;
                    case AnimateObjs.VarType.Float:
                        float value = animateObjects[i].objectToAnimate.GetFloat(animateObjects[i].varName);
                        animateObjects[i].floatBefore = animateObjects[i].floatValue;
                        animateObjects[i].objectToAnimate.SetFloat(animateObjects[i].varName, animateObjects[i].floatBefore);
                        animateObjects[i].floatBefore = value;
                        break;
                    case AnimateObjs.VarType.Integer:
                        int valueI = animateObjects[i].objectToAnimate.GetInteger(animateObjects[i].varName);
                        animateObjects[i].intBefore = animateObjects[i].integerValue;
                        animateObjects[i].objectToAnimate.SetInteger(animateObjects[i].varName, animateObjects[i].intBefore);
                        animateObjects[i].intBefore = valueI;
                        break;
                }
            }

        foreach(MaterialChange obj in materialChangePropetys)
        {
            if (obj.whos)
            {
                if (obj.backMatChange == null)
                    obj.backMatChange = new MaterialChange();
                if (obj.changeTo)
                {
                    if(!obj.toggle)
                        obj.backMatChange.changeTo = obj.whos.materials[obj.matIndex];
                    obj.whos.materials[obj.matIndex] = obj.toggle ? obj.backMatChange.changeTo : obj.changeTo;
                    obj.toggle = !obj.toggle;
                }
                if(obj.changePropetyName.Length > 0)
                {
                    if (obj.changeFloat)
                    {
                        if (!obj.toggle)
                            obj.backMatChange.changePropetyValueFloat = obj.whos.sharedMaterials[obj.matIndex].GetFloat(obj.changePropetyName);
                        obj.whos.materials[obj.matIndex].SetFloat(obj.changePropetyName, obj.toggle ? obj.backMatChange.changePropetyValueFloat : obj.changePropetyValueFloat);
                        obj.toggle = !obj.toggle;
                    }
                    if (obj.changeInt)
                    {
                        if (!obj.toggle)
                            obj.backMatChange.changePropetyValueInteger = obj.whos.sharedMaterials[obj.matIndex].GetInt(obj.changePropetyName);
                        obj.whos.materials[obj.matIndex].SetInt(obj.changePropetyName, obj.toggle ? obj.backMatChange.changePropetyValueInteger : obj.changePropetyValueInteger);
                        obj.toggle = !obj.toggle;
                    }
                    if (obj.changeColor)
                    {
                        if (!obj.toggle)
                            obj.backMatChange.changePropetyColor = obj.whos.sharedMaterials[obj.matIndex].GetColor(obj.changePropetyName);
                        obj.whos.materials[obj.matIndex].SetColor(obj.changePropetyName, obj.toggle ? obj.backMatChange.changePropetyColor : obj.changePropetyColor);
                        obj.toggle = !obj.toggle;
                    }
                }
            }
        }

        foreach (Interactable obj in autoInteract)
            obj.Interact();

        tempoRecuo = recuo;
    }
}
