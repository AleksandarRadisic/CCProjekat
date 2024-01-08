#!/bin/bash

kubectl delete pvc belgrade-library-db-pvc
kubectl delete pv belgrade-library-db-pv

kubectl delete pvc nis-library-db-pvc
kubectl delete pv nis-library-db-pv

kubectl delete pvc novi-sad-library-db-pvc
kubectl delete pv novi-sad-library-db-pv

kubectl delete pvc central-library-db-pvc
kubectl delete pv central-library-db-pv