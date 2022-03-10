#!/bin/bash

n=300
jmxname=monotest

echo "Starting $testName..."

echo "Starting performance monitor..."
logman start 'Petstore Monitor'

echo "Starting Intel Power Gadget logging..."
IntelPowerGadget.exe -start

echo "Sleeping for $n seconds before starting JMeter test..."
sleep "${n}"

echo "Starting JMeter $jmxname test..."
./jmeter.sh -n -t "monotest.jmx"

echo "Sleeping for $n seconds before ending test..."
sleep "${n}"

echo "Stopping performance monitor..."
logman stop 'Petstore Monitor'

echo "Stopping Intel Power Gadget..."
IntelPowerGadget.exe -stop
