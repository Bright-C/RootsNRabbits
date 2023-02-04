using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class InteractWithCollisionBehaviour<T> : MonoBehaviour where T : Component
{
    [ReadOnly] private bool interactOnTriggerEnter = false;
    [ReadOnly] private bool interactOnTriggerExit = false;
    [ReadOnly] private bool interactOnTriggerStay = false;
    [ReadOnly] private bool interactOnCollisionEnter = false;
    [ReadOnly] private bool interactOnCollisionExit = false;
    [ReadOnly] private bool interactOnCollisionStay = false;

    protected virtual void OnTriggerEnterInteraction(T component) { }
    protected virtual void OnTriggerExitInteraction(T component) { }
    protected virtual void OnTriggerStayInteraction(T component) { }
    protected virtual void OnCollisionEnterInteraction(T component) { }
    protected virtual void OnCollisionExitInteraction(T component) { }
    protected virtual void OnCollisionStayInteraction(T component) { }

    static class ReflectionMethodNames
    {
        public static string TriggerEnter { get { return "OnTriggerEnterInteraction"; } }
        public static string TriggerExit { get { return "OnTriggerExitInteraction"; } }
        public static string TriggerStay { get { return "OnTriggerStayInteraction"; } }
        public static string CollisionEnter { get { return "OnCollisionEnterInteraction"; } }
        public static string CollisionExit { get { return "OnCollisionExitInteraction"; } }
        public static string CollisionStay { get { return "OnCollisionStayInteraction"; } }
    }

    protected virtual void Awake()
    {
        MethodInfo m_onTriggerEnter = GetType().GetMethod(ReflectionMethodNames.TriggerEnter, BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo m_onTriggerExit = GetType().GetMethod(ReflectionMethodNames.TriggerExit, BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo m_onTriggerStay = GetType().GetMethod(ReflectionMethodNames.TriggerStay, BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo m_onCollisionEnter = GetType().GetMethod(ReflectionMethodNames.CollisionEnter, BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo m_onCollisionExit = GetType().GetMethod(ReflectionMethodNames.CollisionExit, BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo m_onCollisionStay = GetType().GetMethod(ReflectionMethodNames.CollisionStay, BindingFlags.Instance | BindingFlags.NonPublic);

        interactOnTriggerEnter = m_onTriggerEnter.GetBaseDefinition().DeclaringType != m_onTriggerEnter.DeclaringType;
        interactOnTriggerExit = m_onTriggerExit.GetBaseDefinition().DeclaringType != m_onTriggerExit.DeclaringType;
        interactOnTriggerStay = m_onTriggerStay.GetBaseDefinition().DeclaringType != m_onTriggerStay.DeclaringType;
        interactOnCollisionEnter = m_onCollisionEnter.GetBaseDefinition().DeclaringType != m_onCollisionEnter.DeclaringType;
        interactOnCollisionExit = m_onCollisionExit.GetBaseDefinition().DeclaringType != m_onCollisionExit.DeclaringType;
        interactOnCollisionStay = m_onCollisionStay.GetBaseDefinition().DeclaringType != m_onCollisionStay.DeclaringType;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactOnTriggerEnter)
        {
            T foundComponent = collision.GetComponent<T>();
            if (foundComponent != null)
            {
                OnTriggerEnterInteraction(foundComponent);
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (interactOnTriggerExit)
        {
            T foundComponent = collision.GetComponent<T>();
            if (foundComponent != null)
            {
                OnTriggerExitInteraction(foundComponent);
            }
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (interactOnTriggerStay)
        {
            T foundComponent = collision.GetComponent<T>();
            if (foundComponent != null)
            {
                OnTriggerStayInteraction(foundComponent);
            }
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (interactOnCollisionEnter)
        {
            T foundComponent = collision.collider.GetComponent<T>();
            if (foundComponent != null)
            {
                OnCollisionEnterInteraction(foundComponent);
            }
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (interactOnCollisionExit)
        {
            T foundComponent = collision.collider.GetComponent<T>();
            if (foundComponent != null)
            {
                OnCollisionExitInteraction(foundComponent);
            }
        }
    }

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (interactOnCollisionStay)
        {
            T foundComponent = collision.collider.GetComponent<T>();
            if (foundComponent != null)
            {
                OnCollisionStayInteraction(foundComponent);
            }
        }
    }
}
