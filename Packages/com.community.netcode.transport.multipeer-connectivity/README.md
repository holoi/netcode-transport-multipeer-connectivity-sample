# Multipeer Connectivity Transport for Netcode for GameObjects

## Overview

We implemented the transport layer of Netcode for GameObjects with Apple Multipeer Connectivity, which can enable peer-to-peer communication between nearby devices. By using Multipeer Connectivity, nearby devices can connect to each other when there is no WiFi or cellular network. Furthermore, Multipeer Connectivity is the technology behind AirDrop, which means it can transfer large file between devices very fast. Please reference Apple's official document for detailed information: https://developer.apple.com/documentation/multipeerconnectivity.

## Host-Client Architecture vs Peer-To-Peer Architecture

Before using this transport, it is important to know that Netcode for GameObjects uses a host-client network architecture while Multipeer Connectivity uses a peer-to-peer architecture.

In a host-client network, one device hosts the network and other devices join the network as clients. The host can communicate with all connected clients but a client can only directly communicate with the host. For two connected client, the messages they send to each other must be relayed by the host.

In a peer-to-peer network, there is no host device and all devices are connected as peers. Therefore, any two peers can directly send messages to each other.

In this transport, we wrapped Multipeer Connectivity in a host-client manner to fit the architecture of Netcode for GameObjects.

## The Concept of Advertising and Browsing

In Multipeer Connectivity, an advertiser is a device which advertises itself and a browser is a device which browses nearby advertising peers. Therefore, when establishing the network, the host device should be an advertiser and all other devices should be browsers.

When a host starts the network, it starts to advertise itself so that nearby clients (browsers) can detect it. When a browser finds a nearby host (an advertiser), it sends a connection request to the host. If the host approves the connection request, the sender of the connection request will be connected to the network as a client.

## How to Setup The Nearby Connection
