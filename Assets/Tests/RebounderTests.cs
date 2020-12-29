using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RebounderTests
{
    private static Rebounder SetUpRebounder()
    {
        GameObject camera = new GameObject("Camera", typeof(GamplayCamera));
        camera.GetComponent<GamplayCamera>().Start();
        GameObject unit = new GameObject("Unit", typeof(Rebounder));
        Rebounder rebounder = unit.GetComponent<Rebounder>();
        rebounder.bounds = new Bounds(Vector3.zero, Vector3.one);
        return rebounder;
    }
    [Test]
    public void positive_x_center_does_not_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.x, 0, 0);
        rebounder.FixedUpdate();
        Assert.AreEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void negitive_x_center_does_not_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.x, 0, 0);
        rebounder.FixedUpdate();
        Assert.AreEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void positive_x_edge_does_not_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.x - .5f, 0, 0);
        rebounder.FixedUpdate();
        Assert.AreEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void negitive_x_edge_does_not_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.x + .5f, 0, 0);
        rebounder.FixedUpdate();
        Assert.AreEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void positive_x_edge_does_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.x + .6f, 0, 0);
        rebounder.FixedUpdate();
        Assert.AreNotEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void negitive_x_edge_does_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.x - .6f, 0, 0);
        rebounder.FixedUpdate();
        Assert.AreNotEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void positive_y_center_does_not_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(0, GamplayCamera.instance.CameraBounds.extents.y, 0);
        rebounder.FixedUpdate();
        Assert.AreEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void negitive_y_center_does_not_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(0, -GamplayCamera.instance.CameraBounds.extents.y, 0);
        rebounder.FixedUpdate();
        Assert.AreEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void positive_y_edge_does_not_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(0, GamplayCamera.instance.CameraBounds.extents.y - .5f, 0);
        rebounder.FixedUpdate();
        Assert.AreEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void negitive_y_edge_does_not_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(0, -GamplayCamera.instance.CameraBounds.extents.y + .5f, 0);
        rebounder.FixedUpdate();
        Assert.AreEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void positive_y_edge_does_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(0, GamplayCamera.instance.CameraBounds.extents.y + .6f, 0);
        rebounder.FixedUpdate();
        Assert.AreNotEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void negitive_y_edge_does_rebound()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(0, -GamplayCamera.instance.CameraBounds.extents.y - .6f, 0);
        rebounder.FixedUpdate();
        Assert.AreNotEqual(oldPos, rebounder.transform.position);
    }
    [Test]
    public void positive_x_slight_positive_y_only_rebounds()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.y + .6f, .1f, 0);
        rebounder.FixedUpdate();
        Assert.AreNotEqual(new Vector3(-(GamplayCamera.instance.CameraBounds.extents.y + .6f), .1f, 0), rebounder.transform.position);
    }
    [Test]
    public void negitive_x_slight_positive_y_only_rebounds()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.y - .6f, .1f, 0);
        rebounder.FixedUpdate();
        Assert.AreNotEqual(new Vector3(-(-GamplayCamera.instance.CameraBounds.extents.y - .6f), .1f, 0), rebounder.transform.position);
    }
    [Test]
    public void positive_x_slight_negitive_y_only_rebounds()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.y + .6f, -.1f, 0);
        rebounder.FixedUpdate();
        Assert.AreNotEqual(new Vector3(-(GamplayCamera.instance.CameraBounds.extents.y + .6f), -.1f, 0), rebounder.transform.position);
    }
    [Test]
    public void negitive_x_slight_negitive_y_only_rebounds()
    {
        Rebounder rebounder = SetUpRebounder();
        Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.y - .6f, -.1f, 0);
        rebounder.FixedUpdate();
        Assert.AreNotEqual(new Vector3(-(-GamplayCamera.instance.CameraBounds.extents.y - .6f), -.1f, 0), rebounder.transform.position);
    }
}

