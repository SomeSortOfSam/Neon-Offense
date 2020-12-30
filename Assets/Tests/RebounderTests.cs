using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace RebounderTests
{
    public class Setup
    {
        public static Rebounder SetUpRebounder()
        {
            GameObject camera = new GameObject("Camera", typeof(GamplayCamera));
            camera.GetComponent<GamplayCamera>().Start();
            GameObject unit = new GameObject("Unit", typeof(Rebounder));
            Rebounder rebounder = unit.GetComponent<Rebounder>();
            rebounder.bounds = new Bounds(Vector3.zero, Vector3.one);
            return rebounder;
        }
    }
    public class Fails_On_Edge
    {
        [Test]
        public void positive_x()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.x - .5f, 0, 0);
            rebounder.FixedUpdate();
            Assert.AreEqual(oldPos, rebounder.transform.position);
        }
        [Test]
        public void negitive_x()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.x + .5f, 0, 0);
            rebounder.FixedUpdate();
            Assert.AreEqual(oldPos, rebounder.transform.position);
        }
        [Test]
        public void positive_y()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(0, GamplayCamera.instance.CameraBounds.extents.y - .5f, 0);
            rebounder.FixedUpdate();
            Assert.AreEqual(oldPos, rebounder.transform.position);
        }
        [Test]
        public void negitive_y()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(0, -GamplayCamera.instance.CameraBounds.extents.y + .5f, 0);
            rebounder.FixedUpdate();
            Assert.AreEqual(oldPos, rebounder.transform.position);
        }
    }
    public class Fails_On_Center
    {
        [Test]
        public void positive_x()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.x, 0, 0);
            rebounder.FixedUpdate();
            Assert.AreEqual(oldPos, rebounder.transform.position);
        }
        [Test]
        public void negitive_x()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.x, 0, 0);
            rebounder.FixedUpdate();
            Assert.AreEqual(oldPos, rebounder.transform.position);
        }
        [Test]
        public void positive_y()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(0, GamplayCamera.instance.CameraBounds.extents.y, 0);
            rebounder.FixedUpdate();
            Assert.AreEqual(oldPos, rebounder.transform.position);
        }
        [Test]
        public void negitive_y()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(0, -GamplayCamera.instance.CameraBounds.extents.y, 0);
            rebounder.FixedUpdate();
            Assert.AreEqual(oldPos, rebounder.transform.position);
        }
    }
    public class Rebounds_On_Edge
    {
        [Test]
        public void positive_x()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.x + .6f, 0, 0);
            rebounder.FixedUpdate();
            Assert.AreNotEqual(oldPos, rebounder.transform.position);
        }
        [Test]
        public void negitive_x()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.x - .6f, 0, 0);
            rebounder.FixedUpdate();
            Assert.AreNotEqual(oldPos, rebounder.transform.position);
        }
        [Test]
        public void positive_y()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(0, GamplayCamera.instance.CameraBounds.extents.y + .6f, 0);
            rebounder.FixedUpdate();
            Assert.AreNotEqual(oldPos, rebounder.transform.position);
        }
        [Test]
        public void negitive_y()
        {
            Rebounder rebounder = Setup.SetUpRebounder();
            Vector3 oldPos = rebounder.transform.position = new Vector3(0, -GamplayCamera.instance.CameraBounds.extents.y - .6f, 0);
            rebounder.FixedUpdate();
            Assert.AreNotEqual(oldPos, rebounder.transform.position);
        }
    }
    namespace Only_Rebounds_On_One_Axis
    {
        public class One_Rebound_Slight_Distruption
        {
            [Test]
            public void positive_x_slight_positive_y()
            {
                Rebounder rebounder = Setup.SetUpRebounder();
                Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.y + .6f, .1f, 0);
                rebounder.FixedUpdate();
                Assert.AreEqual(.1f, rebounder.transform.position.y);
            }
            [Test]
            public void negitive_x_slight_positive_y()
            {
                Rebounder rebounder = Setup.SetUpRebounder();
                Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.y - .6f, .1f, 0);
                rebounder.FixedUpdate();
                Assert.AreEqual(.1f, rebounder.transform.position.y);
            }
            [Test]
            public void positive_x_slight_negitive_y()
            {
                Rebounder rebounder = Setup.SetUpRebounder();
                Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.y + .6f, -.1f, 0);
                rebounder.FixedUpdate();
                Assert.AreEqual(-.1f, rebounder.transform.position.y);
            }
            [Test]
            public void negitive_x_slight_negitive_y()
            {
                Rebounder rebounder = Setup.SetUpRebounder();
                Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.y - .6f, -.1f, 0);
                rebounder.FixedUpdate();
                Assert.AreEqual(-.1f, rebounder.transform.position.y);
            }
        }
        public class Two_Rebound_Slight_Distruption
        {
            [Test]
            public void positive_x_slight_positive_y()
            {
                Rebounder rebounder = Setup.SetUpRebounder();
                Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.y + .6f, .1f, 0);
                rebounder.FixedUpdate();
                rebounder.FixedUpdate();
                Assert.AreEqual(.1f, rebounder.transform.position.y);
            }
            [Test]
            public void negitive_x_slight_positive_y()
            {
                Rebounder rebounder = Setup.SetUpRebounder();
                Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.y - .6f, .1f, 0);
                rebounder.FixedUpdate();
                rebounder.FixedUpdate();
                Assert.AreEqual(.1f, rebounder.transform.position.y);
            }
            [Test]
            public void positive_x_slight_negitive_y()
            {
                Rebounder rebounder = Setup.SetUpRebounder();
                Vector3 oldPos = rebounder.transform.position = new Vector3(GamplayCamera.instance.CameraBounds.extents.y + .6f, -.1f, 0);
                rebounder.FixedUpdate();
                rebounder.FixedUpdate();
                Assert.AreEqual(-.1f, rebounder.transform.position.y);
            }
            [Test]
            public void negitive_x_slight_negitive_y()
            {
                Rebounder rebounder = Setup.SetUpRebounder();
                Vector3 oldPos = rebounder.transform.position = new Vector3(-GamplayCamera.instance.CameraBounds.extents.y - .6f, -.1f, 0);
                rebounder.FixedUpdate();
                rebounder.FixedUpdate();
                Assert.AreEqual(-.1f, rebounder.transform.position.y);
            }
        }
    }

}
