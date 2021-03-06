/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

/*
 *
 *  Marshaler code for OpenWire format for ConsumerInfo
 *
 *  NOTE!: This file is auto generated - do not modify!
 *         if you need to make a change, please see the Java Classes
 *         in the nms-activemq-openwire-generator module
 *
 */

using System;
using System.IO;

using Apache.NMS.ActiveMQ.Commands;

namespace Apache.NMS.ActiveMQ.OpenWire.V9
{
    /// <summary>
    ///  Marshalling code for Open Wire Format for ConsumerInfo
    /// </summary>
    class ConsumerInfoMarshaller : BaseCommandMarshaller
    {
        /// <summery>
        ///  Creates an instance of the Object that this marshaller handles.
        /// </summery>
        public override DataStructure CreateObject() 
        {
            return new ConsumerInfo();
        }

        /// <summery>
        ///  Returns the type code for the Object that this Marshaller handles..
        /// </summery>
        public override byte GetDataStructureType() 
        {
            return ConsumerInfo.ID_CONSUMERINFO;
        }

        // 
        // Un-marshal an object instance from the data input stream
        // 
        public override void TightUnmarshal(OpenWireFormat wireFormat, Object o, BinaryReader dataIn, BooleanStream bs) 
        {
            base.TightUnmarshal(wireFormat, o, dataIn, bs);

            ConsumerInfo info = (ConsumerInfo)o;
            info.ConsumerId = (ConsumerId) TightUnmarshalCachedObject(wireFormat, dataIn, bs);
            info.Browser = bs.ReadBoolean();
            info.Destination = (ActiveMQDestination) TightUnmarshalCachedObject(wireFormat, dataIn, bs);
            info.PrefetchSize = dataIn.ReadInt32();
            info.MaximumPendingMessageLimit = dataIn.ReadInt32();
            info.DispatchAsync = bs.ReadBoolean();
            info.Selector = TightUnmarshalString(dataIn, bs);
            info.SubscriptionName = TightUnmarshalString(dataIn, bs);
            info.NoLocal = bs.ReadBoolean();
            info.Exclusive = bs.ReadBoolean();
            info.Retroactive = bs.ReadBoolean();
            info.Priority = dataIn.ReadByte();

            if (bs.ReadBoolean()) {
                short size = dataIn.ReadInt16();
                BrokerId[] value = new BrokerId[size];
                for( int i=0; i < size; i++ ) {
                    value[i] = (BrokerId) TightUnmarshalNestedObject(wireFormat,dataIn, bs);
                }
                info.BrokerPath = value;
            }
            else {
                info.BrokerPath = null;
            }
            info.AdditionalPredicate = (BooleanExpression) TightUnmarshalNestedObject(wireFormat, dataIn, bs);
            info.NetworkSubscription = bs.ReadBoolean();
            info.OptimizedAcknowledge = bs.ReadBoolean();
            info.NoRangeAcks = bs.ReadBoolean();

            if (bs.ReadBoolean()) {
                short size = dataIn.ReadInt16();
                ConsumerId[] value = new ConsumerId[size];
                for( int i=0; i < size; i++ ) {
                    value[i] = (ConsumerId) TightUnmarshalNestedObject(wireFormat,dataIn, bs);
                }
                info.NetworkConsumerPath = value;
            }
            else {
                info.NetworkConsumerPath = null;
            }
        }

        //
        // Write the booleans that this object uses to a BooleanStream
        //
        public override int TightMarshal1(OpenWireFormat wireFormat, Object o, BooleanStream bs)
        {
            ConsumerInfo info = (ConsumerInfo)o;

            int rc = base.TightMarshal1(wireFormat, o, bs);
            rc += TightMarshalCachedObject1(wireFormat, (DataStructure)info.ConsumerId, bs);
            bs.WriteBoolean(info.Browser);
            rc += TightMarshalCachedObject1(wireFormat, (DataStructure)info.Destination, bs);
            bs.WriteBoolean(info.DispatchAsync);
            rc += TightMarshalString1(info.Selector, bs);
            rc += TightMarshalString1(info.SubscriptionName, bs);
            bs.WriteBoolean(info.NoLocal);
            bs.WriteBoolean(info.Exclusive);
            bs.WriteBoolean(info.Retroactive);
            rc += TightMarshalObjectArray1(wireFormat, info.BrokerPath, bs);
        rc += TightMarshalNestedObject1(wireFormat, (DataStructure)info.AdditionalPredicate, bs);
            bs.WriteBoolean(info.NetworkSubscription);
            bs.WriteBoolean(info.OptimizedAcknowledge);
            bs.WriteBoolean(info.NoRangeAcks);
            rc += TightMarshalObjectArray1(wireFormat, info.NetworkConsumerPath, bs);

            return rc + 9;
        }

        // 
        // Write a object instance to data output stream
        //
        public override void TightMarshal2(OpenWireFormat wireFormat, Object o, BinaryWriter dataOut, BooleanStream bs)
        {
            base.TightMarshal2(wireFormat, o, dataOut, bs);

            ConsumerInfo info = (ConsumerInfo)o;
            TightMarshalCachedObject2(wireFormat, (DataStructure)info.ConsumerId, dataOut, bs);
            bs.ReadBoolean();
            TightMarshalCachedObject2(wireFormat, (DataStructure)info.Destination, dataOut, bs);
            dataOut.Write(info.PrefetchSize);
            dataOut.Write(info.MaximumPendingMessageLimit);
            bs.ReadBoolean();
            TightMarshalString2(info.Selector, dataOut, bs);
            TightMarshalString2(info.SubscriptionName, dataOut, bs);
            bs.ReadBoolean();
            bs.ReadBoolean();
            bs.ReadBoolean();
            dataOut.Write(info.Priority);
            TightMarshalObjectArray2(wireFormat, info.BrokerPath, dataOut, bs);
            TightMarshalNestedObject2(wireFormat, (DataStructure)info.AdditionalPredicate, dataOut, bs);
            bs.ReadBoolean();
            bs.ReadBoolean();
            bs.ReadBoolean();
            TightMarshalObjectArray2(wireFormat, info.NetworkConsumerPath, dataOut, bs);
        }

        // 
        // Un-marshal an object instance from the data input stream
        // 
        public override void LooseUnmarshal(OpenWireFormat wireFormat, Object o, BinaryReader dataIn) 
        {
            base.LooseUnmarshal(wireFormat, o, dataIn);

            ConsumerInfo info = (ConsumerInfo)o;
            info.ConsumerId = (ConsumerId) LooseUnmarshalCachedObject(wireFormat, dataIn);
            info.Browser = dataIn.ReadBoolean();
            info.Destination = (ActiveMQDestination) LooseUnmarshalCachedObject(wireFormat, dataIn);
            info.PrefetchSize = dataIn.ReadInt32();
            info.MaximumPendingMessageLimit = dataIn.ReadInt32();
            info.DispatchAsync = dataIn.ReadBoolean();
            info.Selector = LooseUnmarshalString(dataIn);
            info.SubscriptionName = LooseUnmarshalString(dataIn);
            info.NoLocal = dataIn.ReadBoolean();
            info.Exclusive = dataIn.ReadBoolean();
            info.Retroactive = dataIn.ReadBoolean();
            info.Priority = dataIn.ReadByte();

            if (dataIn.ReadBoolean()) {
                short size = dataIn.ReadInt16();
                BrokerId[] value = new BrokerId[size];
                for( int i=0; i < size; i++ ) {
                    value[i] = (BrokerId) LooseUnmarshalNestedObject(wireFormat,dataIn);
                }
                info.BrokerPath = value;
            }
            else {
                info.BrokerPath = null;
            }
            info.AdditionalPredicate = (BooleanExpression) LooseUnmarshalNestedObject(wireFormat, dataIn);
            info.NetworkSubscription = dataIn.ReadBoolean();
            info.OptimizedAcknowledge = dataIn.ReadBoolean();
            info.NoRangeAcks = dataIn.ReadBoolean();

            if (dataIn.ReadBoolean()) {
                short size = dataIn.ReadInt16();
                ConsumerId[] value = new ConsumerId[size];
                for( int i=0; i < size; i++ ) {
                    value[i] = (ConsumerId) LooseUnmarshalNestedObject(wireFormat,dataIn);
                }
                info.NetworkConsumerPath = value;
            }
            else {
                info.NetworkConsumerPath = null;
            }
        }

        // 
        // Write a object instance to data output stream
        //
        public override void LooseMarshal(OpenWireFormat wireFormat, Object o, BinaryWriter dataOut)
        {

            ConsumerInfo info = (ConsumerInfo)o;

            base.LooseMarshal(wireFormat, o, dataOut);
            LooseMarshalCachedObject(wireFormat, (DataStructure)info.ConsumerId, dataOut);
            dataOut.Write(info.Browser);
            LooseMarshalCachedObject(wireFormat, (DataStructure)info.Destination, dataOut);
            dataOut.Write(info.PrefetchSize);
            dataOut.Write(info.MaximumPendingMessageLimit);
            dataOut.Write(info.DispatchAsync);
            LooseMarshalString(info.Selector, dataOut);
            LooseMarshalString(info.SubscriptionName, dataOut);
            dataOut.Write(info.NoLocal);
            dataOut.Write(info.Exclusive);
            dataOut.Write(info.Retroactive);
            dataOut.Write(info.Priority);
            LooseMarshalObjectArray(wireFormat, info.BrokerPath, dataOut);
            LooseMarshalNestedObject(wireFormat, (DataStructure)info.AdditionalPredicate, dataOut);
            dataOut.Write(info.NetworkSubscription);
            dataOut.Write(info.OptimizedAcknowledge);
            dataOut.Write(info.NoRangeAcks);
            LooseMarshalObjectArray(wireFormat, info.NetworkConsumerPath, dataOut);
        }
    }
}
