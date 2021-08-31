// DO NOT EDIT: GENERATED BY Vector3PackTestGenerator.cs

using System;
using System.Collections;
using Mirage.Serialization;
using Mirage.Tests.Runtime.ClientServer;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Mirage.Tests.Runtime.Generated.Vector3PackAttributeTests
{
    public class Vector3PackBehaviour_1000_42f : NetworkBehaviour
    {
        [Vector3Pack(1000f, 200f, 1000f, 0.1f)]
        [SyncVar] public Vector3 myValue;
    }
    public class Vector3PackTest_1000_42f : ClientServerSetup<Vector3PackBehaviour_1000_42f>
    {
        static readonly Vector3 value = new Vector3(-10.3f, 0.2f, 20f);
        const float within = 0.1f;

        [Test]
        public void SyncVarIsBitPacked()
        {
            serverComponent.myValue = value;

            using (PooledNetworkWriter writer = NetworkWriterPool.GetWriter())
            {
                serverComponent.SerializeSyncVars(writer, true);

                Assert.That(writer.BitPosition, Is.EqualTo(42));

                using (PooledNetworkReader reader = NetworkReaderPool.GetReader(writer.ToArraySegment()))
                {
                    clientComponent.DeserializeSyncVars(reader, true);
                    Assert.That(reader.BitPosition, Is.EqualTo(42));

                    Assert.That(clientComponent.myValue.x, Is.EqualTo(value.x).Within(within));
                    Assert.That(clientComponent.myValue.y, Is.EqualTo(value.y).Within(within));
                    Assert.That(clientComponent.myValue.z, Is.EqualTo(value.z).Within(within));
                }
            }
        }
    }
}
