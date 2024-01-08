#!/bin/bash

kubectl apply -f central-library-pod.yaml
kubectl apply -f central-library-service.yaml

kubectl apply -f novi-sad-library-pod.yaml
kubectl apply -f novi-sad-library-service.yaml

kubectl apply -f belgrade-library-pod.yaml
kubectl apply -f belgrade-library-service.yaml

kubectl apply -f nis-library-pod.yaml
kubectl apply -f nis-library-service.yaml

read -p "Press Enter to continue..."