#!/bin/bash

kubectl delete ingress nis-library-ingress
kubectl delete service nis-library-service
kubectl delete pod nis-library-pod

kubectl delete ingress belgrade-library-ingress
kubectl delete service belgrade-library-service
kubectl delete pod belgrade-library-pod

kubectl delete ingress novi-sad-library-ingress
kubectl delete service novi-sad-library-service
kubectl delete pod novi-sad-library-pod

kubectl delete ingress central-library-ingress
kubectl delete service central-library-service
kubectl delete pod central-library-pod

read -p "Press Enter to continue..."
