#!/bin/bash
dotnet run --project simulation config.json > /dev/null
cat benchmark.json
