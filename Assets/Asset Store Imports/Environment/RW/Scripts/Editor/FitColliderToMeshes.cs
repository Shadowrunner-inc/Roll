/*
 * Copyright (c) 2018 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using UnityEngine;
using UnityEditor;

/// <summary>
/// FitColliderToMeshes script by @BlackDragonBE
/// This helpder script allows you to automatically create a box collider shape that envelops all of the child meshes.
/// 
/// Usage:
/// 1. Select parent GameObject(s) with mesh children.
/// 2. Add a Box Collider.
/// 3. Select Tools > Fit collider to children in the top menu.
/// </summary>
public class FitColliderToMeshes : MonoBehaviour
{
    [MenuItem("Tools/Fit collider to children")]
    static void FitToChildren()
    {
        foreach (GameObject parentObject in Selection.gameObjects)
        {
            if (!(parentObject.GetComponent<Collider>() is BoxCollider))
            {
                continue;
            }

            bool hasBounds = false;
            Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

            for (int i = 0; i < parentObject.transform.childCount; ++i)
            {
                Renderer childRenderer = parentObject.transform.GetChild(i).GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    if (hasBounds)
                    {
                        bounds.Encapsulate(childRenderer.bounds);
                    }
                    else
                    {
                        bounds = childRenderer.bounds;
                        hasBounds = true;
                    }
                }
            }

            BoxCollider collider = (BoxCollider)parentObject.GetComponent<Collider>();
            collider.center = bounds.center - parentObject.transform.position;
            collider.size = bounds.size;
        }
    }

}